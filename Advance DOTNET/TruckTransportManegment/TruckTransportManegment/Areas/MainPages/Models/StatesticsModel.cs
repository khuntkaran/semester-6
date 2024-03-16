namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class StatesticsModel
    {
        public int TruckCount { get; set; }
        public int OrderCount { get;set; }
        public int UserCount { get; set; }
        public int DriverCount { get; set; }

        public List<StatesticsTimeline> Timeline { get; set; }
    }

    public class StatesticsTimeline
    {
        public string PickUpCityName { get; set; }
        public string DropCityName { get; set; }
        public int TotalOrder { get; set; }
    }
}
