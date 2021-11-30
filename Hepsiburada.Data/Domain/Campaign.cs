
namespace Hepsiburada.Data.Domain
{
    public class Campaign
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public CampaignStatuses Status { get; set; }
    }

    public enum CampaignStatuses
    {
        Active = 1,
        Ended = 2
    }
}