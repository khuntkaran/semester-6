using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class BookingModel
    {
        public int?      BookingID { get; set; }
        public int      UserID { get; set; }
        public string UserName { get; set; }
        [Required]
        public int      TruckID     { get; set; }
        public string   TruckName { get; set; }
        [Required]
        public int      PickUpCityID   { get; set; }
        public string   PickUpCityName { get; set; }
        [Required]
        public int      DropCityID     { get; set; }
        public string   DropCityName { get; set; }
        [Required]
        public int      GoodsTypeID    { get; set; }
        public string   GoodsTypeName { get; set; }
        [Required]
        public int      DriverID { get; set; }
        public string   DriverName { get; set; }
        [Required]
        public double?   Distance { get; set; }
        [Required]
        public double?   Price { get; set; }
        [Required]
        public double?   Weight { get; set; }
        [Required]
        public DateTime? PickUpDate { get; set; }
        [Required]
        public DateTime? DropDate { get; set; }
        [Required]
        public string   FromAddress { get; set; }
        [Required]
        public string   ToAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        public List<CityModel> Cities { get; set; }
        public List<TruckModel> Trucks { get; set; }
        public List<GoodsTypeModel> Goods { get; set; }
        public List<DriverModel> Drivers { get; set; }

    }
}
