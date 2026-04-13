namespace Room_Api.models
{
    public class PricingRule
    {
        public int Id { get; set; }
        public string RuleName { get; set; }
        public string RuleType { get; set; }        // "Demand", "Season", "Weekend"
        public decimal MultiplierPercent { get; set; } // e.g. 20 = +20%
        public int? DemandThresholdPercent { get; set; } // Trigger at X% occupancy
        public DateTime? SeasonStart { get; set; }
        public DateTime? SeasonEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
