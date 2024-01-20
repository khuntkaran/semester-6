using System.Net;

namespace TruckTransportManegment.Areas.MainPages.Models
{
    public class BookingModel
    {
        public int      BookingID { get; set; }
        public int      UserID { get; set; }
        public int      TruckID     { get; set; }
        public string   TruckName { get; set; }
        public int      PickUpCityID   { get; set; }
        public string   PickUpCityName { get; set; }
        public int      DropCityID     { get; set; }
        public string   DropCityName { get; set; }
        public int      GoodsTypeID    { get; set; }
        public string   GoodsTypeName { get; set; }
        public int      DriverID { get; set; }
        public string   DriverName { get; set; }
        public double   Distance { get; set; }
        public double   Price { get; set; }
        public double   Weight { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropDate { get; set; }
        public string   FromAddress { get; set; }
        public string   ToAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        public List<CityModel> Cities { get; set; }
        public List<TruckModel> Trucks { get; set; }
        public List<GoodsTypeModel> Goods { get; set; }
        public List<DriverModel> Drivers { get; set; }

    }
}
