namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class TruckModel
    {
        public  int TruckID { get; set; }
        public string TruckName { get; set;}
        public string TruckType { get; set; }
        public double Capacity { get; set; }
        public string TruckNumber { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
