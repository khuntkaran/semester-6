using System.ComponentModel.DataAnnotations;

namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class TruckModel
    {
        public  int? TruckID { get; set; }
        [Required]
        public string TruckName { get; set;}
        [Required]
        public string TruckType { get; set; }
        [Required]
        public double Capacity { get; set; }
        [Required]
        public string TruckNumber { get; set; }
        [Required]
        public string EngineNo { get; set; }
        [Required]
        public string ChasisNo { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
