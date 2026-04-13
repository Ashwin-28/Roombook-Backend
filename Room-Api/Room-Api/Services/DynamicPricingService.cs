using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Room_Api.Data;
using Room_Api.Services.Dto;
using Room_Api.Services.Interfaces;

namespace Room_Api.Services
{
    public class DynamicPricingService : IDynamicPricingService
    {
        private readonly AppDbContext _context;

        public DynamicPricingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> CalculatePriceAsync(int roomId, DateTime checkIn, DateTime checkOut, int numRooms)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null) throw new ArgumentException("Invalid room id", nameof(roomId));

            var basePrice = room.BasePrice;
            var totalDays = Math.Max(1, (checkOut - checkIn).Days);
            var multiplier = 1.0m;

            // 1. DEMAND-BASED: Check current occupancy %
            var totalRooms = Math.Max(1, room.TotalRooms);
            var bookedRooms = await _context.Bookings
                .Where(b => b.RoomId == roomId && b.Status != "Cancelled" && b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                .SumAsync(b => (int?)b.NumberOfRooms) ?? 0;

            var occupancyPercent = (int)((double)bookedRooms / totalRooms * 100);

            var demandRules = await _context.PricingRules
                .Where(r => r.RuleType == "Demand" && r.IsActive && r.DemandThresholdPercent <= occupancyPercent)
                .OrderByDescending(r => r.DemandThresholdPercent)
                .FirstOrDefaultAsync();

            if (demandRules != null)
                multiplier += demandRules.MultiplierPercent / 100;

            // 2. SEASON-BASED: Check if dates fall in peak season
            var seasonRules = await _context.PricingRules
                .Where(r => r.RuleType == "Season" && r.IsActive && r.SeasonStart <= checkIn && r.SeasonEnd >= checkOut)
                .ToListAsync();

            foreach (var rule in seasonRules)
                multiplier += rule.MultiplierPercent / 100;

            // 3. WEEKEND SURCHARGE
            if (checkIn.DayOfWeek == DayOfWeek.Friday || checkIn.DayOfWeek == DayOfWeek.Saturday)
            {
                var weekendRule = await _context.PricingRules
                    .FirstOrDefaultAsync(r => r.RuleType == "Weekend" && r.IsActive);
                if (weekendRule != null)
                    multiplier += weekendRule.MultiplierPercent / 100;
            }

            return basePrice * multiplier * totalDays * numRooms;
        }

        public async Task<PriceEstimateResponseDto> GetPriceEstimateAsync(PriceEstimateRequestDto dto)
        {
            var room = await _context.Rooms.FindAsync(dto.RoomId);
            if (room == null) throw new ArgumentException("Invalid room id", nameof(dto.RoomId));

            var days = Math.Max(1, (dto.CheckOutDate - dto.CheckInDate).Days);

            var totalPrice = await CalculatePriceAsync(
                dto.RoomId, dto.CheckInDate, dto.CheckOutDate, dto.NumberOfRooms);

            return new PriceEstimateResponseDto
            {
                BasePrice = room.BasePrice,
                FinalPricePerNight = totalPrice / days / dto.NumberOfRooms,
                TotalEstimate = totalPrice,
                PricingNote = "Price adjusted based on demand and season."
            };
        }
    }
}
