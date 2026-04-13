namespace Room_Api.DTOs
{
    public class PriceEstimateResponseDto
    {
        public decimal BasePrice { get; set; }
        public decimal DemandSurchargePercent { get; set; }
        public decimal SeasonSurchargePercent { get; set; }
        public decimal FinalPricePerNight { get; set; }
        public decimal TotalEstimate { get; set; }
        public string PricingNote { get; set; }   // e.g. "High demand season!"
    }
}
