using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;
using DriverTransportManegment.DAL;
using System.Net;

namespace TruckTransportManegment.DAL
{
    public class Booking_DALBase
    {
        public List<BookingModel> Order_SelectAll()
        {
            try
            {
                /*City_DALBase city_DALBase = new City_DALBase();
                Driver_DALBase driver_DALBase = new Driver_DALBase();
                GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
                Truck_DALBase truck_DALBase = new Truck_DALBase();

                List<CityModel> cityModel = city_DALBase.City_SelectAll();
                List<DriverModel> driverModel = driver_DALBase.Driver_SelectAll();
                List<GoodsTypeModel> goodsTypeModel = goodsType_DALBase.GoodsType_SelectAll();
                List<TruckModel>  truckModel = truck_DALBase.Truck_SelectAll();
*/


                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_TruckWiseBooking_SelectAll");
                List<BookingModel> bookingModels = new List<BookingModel>();
                
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        BookingModel bookingModel = new BookingModel();
                        bookingModel.BookingID= Convert.ToInt32(dr["BookingID"].ToString()); 
                        bookingModel.UserID= Convert.ToInt32(dr["UserID"].ToString()); 
                        bookingModel.TruckID=Convert.ToInt32(dr["TruckID"].ToString()); 
                        bookingModel.TruckName=dr["TruckName"].ToString(); 
                        bookingModel.PickUpCityID=Convert.ToInt32(dr["PickUpCityID"].ToString()); 
                        bookingModel.PickUpCityName=dr["PickUpCityName"].ToString(); 
                        bookingModel.DropCityID=Convert.ToInt32(dr["DropCityID"].ToString()); 
                        bookingModel.DropCityName=dr["DropCityName"].ToString(); 
                        bookingModel.GoodsTypeID=Convert.ToInt32(dr["GoodsTypeID"].ToString()); 
                        bookingModel.GoodsTypeName=dr["GoodsTypeName"].ToString(); 
                        bookingModel.DriverID=Convert.ToInt32(dr["DriverID"].ToString()); 
                        bookingModel.DriverName=dr["DriverName"].ToString(); 
                        bookingModel.Distance=Convert.ToDouble(dr["Distance"].ToString()); 
                        bookingModel.Price=Convert.ToDouble(dr["Price"].ToString()); 
                        bookingModel.Weight=Convert.ToDouble(dr["Weight"].ToString()); 
                        bookingModel.PickUpDate= Convert.ToDateTime(dr["PickUpDate"].ToString()); 
                        bookingModel.DropDate= Convert.ToDateTime(dr["DropDate"].ToString()); 
                        bookingModel.FromAddress=dr["FromAddress"].ToString();
                        bookingModel.ToAddress = dr["ToAddress"].ToString(); 
                        bookingModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        bookingModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        bookingModels.Add(bookingModel);
                    }
                }
                return bookingModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
