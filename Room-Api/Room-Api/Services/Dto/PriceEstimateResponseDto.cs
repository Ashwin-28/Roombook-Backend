namespace Room_Api.Services.Dto
{
    public class PriceEstimateResponseDto
    {
        public decimal BasePrice { get; set; }
        public decimal FinalPricePerNight { get; set; }
        public decimal TotalEstimate { get; set; }
        public string PricingNote { get; set; }
    }
}
