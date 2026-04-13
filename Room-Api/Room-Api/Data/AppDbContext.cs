// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Room_Api.models;

namespace Room_Api.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Amenity> Amenities { get; set; } = null!;
    public DbSet<RoomAmenity> RoomAmenities { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<BookingService> BookingServices { get; set; } = null!;
    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<PricingRule> PricingRules { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Composite PK for join table
        builder.Entity<RoomAmenity>()
            .HasKey(ra => new { ra.RoomId, ra.AmenityId });

        // Decimal precision
        builder.Entity<Room>()
            .Property(r => r.BasePrice).HasColumnType("decimal(18,2)");
        builder.Entity<Bill>()
            .Property(b => b.TotalAmount).HasColumnType("decimal(18,2)");

        // Configure Booking decimal precisions
        builder.Entity<Booking>()
            .Property(b => b.BaseAmount).HasColumnType("decimal(18,2)");
        builder.Entity<Booking>()
            .Property(b => b.DynamicPriceAmount).HasColumnType("decimal(18,2)");
        builder.Entity<Booking>()
            .Property(b => b.ServiceAmount).HasColumnType("decimal(18,2)");
        builder.Entity<Booking>()
            .Property(b => b.TotalAmount).HasColumnType("decimal(18,2)");

        // Configure BookingService price precision
        builder.Entity<BookingService>()
            .Property(bs => bs.Price).HasColumnType("decimal(18,2)");

        // Configure PricingRule precision
        builder.Entity<PricingRule>()
            .Property(p => p.MultiplierPercent).HasColumnType("decimal(18,2)");

        // Configure delete behaviors to avoid multiple cascade paths (SQL Server restriction)
        builder.Entity<Booking>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Review>()
            .HasOne(r => r.Booking)
            .WithOne(b => b.Review)
            .HasForeignKey<Review>(r => r.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.Room)
            .WithMany(rm => rm.Reviews)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
