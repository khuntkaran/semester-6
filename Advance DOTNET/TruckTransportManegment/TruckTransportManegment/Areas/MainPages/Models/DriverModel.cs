using System.ComponentModel.DataAnnotations;

namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class DriverModel
    {
        public int? DriverID { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public string LicenceNo { get; set; }
        [Required]
        public string DriverPhone { get; set;}
        [Required]
        public DateTime LicenceExpiryDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
