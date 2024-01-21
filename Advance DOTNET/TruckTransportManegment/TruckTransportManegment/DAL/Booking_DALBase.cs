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

                List<bookingModel> bookingModel = city_DALBase.City_SelectAll();
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

        public BookingModel Add_Edit_Order()
        {
            BookingModel bookingModel = new BookingModel();
            try
            {

                City_DALBase city_DALBase = new City_DALBase();
                Driver_DALBase driver_DALBase = new Driver_DALBase();
                GoodsType_DALBase goodsType_DALBase = new GoodsType_DALBase();
                Truck_DALBase truck_DALBase = new Truck_DALBase();

                bookingModel.Cities = city_DALBase.City_SelectAll();
                bookingModel.Drivers = driver_DALBase.Driver_SelectAll();
                bookingModel.Goods = goodsType_DALBase.GoodsType_SelectAll();
                bookingModel.Trucks = truck_DALBase.Truck_SelectAll();

            }
            catch (Exception ex) { }
            return bookingModel;
        }

        public bool Save(BookingModel bookingModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand;
                if (bookingModel.BookingID != null)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_TruckWiseBooking_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@BookingID", SqlDbType.NVarChar, bookingModel.BookingID);
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_TruckWiseBooking_Insert");
                }
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int,   bookingModel.UserID);
                sqlDatabase.AddInParameter(dbCommand, "@TruckID", SqlDbType.Int,  bookingModel.TruckID);
                sqlDatabase.AddInParameter(dbCommand, "@PickUpCityID", SqlDbType.Int, bookingModel.PickUpCityID);
                sqlDatabase.AddInParameter(dbCommand, "@DropCityID", SqlDbType.Int, bookingModel.DropCityID);
                sqlDatabase.AddInParameter(dbCommand, "@GoodsTypeID", SqlDbType.Int, bookingModel.GoodsTypeID);
                sqlDatabase.AddInParameter(dbCommand, "@DriverID", SqlDbType.Int, bookingModel.DriverID);
                sqlDatabase.AddInParameter(dbCommand, "@Distance", SqlDbType.Decimal, bookingModel.Distance);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, bookingModel.Price);
                sqlDatabase.AddInParameter(dbCommand, "@Weight", SqlDbType.Decimal, bookingModel.Weight);
                sqlDatabase.AddInParameter(dbCommand, "@PickUpDate", SqlDbType.DateTime, bookingModel.PickUpDate);
                sqlDatabase.AddInParameter(dbCommand, "@DropDate", SqlDbType.DateTime, bookingModel.DropDate);
                sqlDatabase.AddInParameter(dbCommand, "@FromAddress", SqlDbType.NVarChar, bookingModel.FromAddress);
                sqlDatabase.AddInParameter(dbCommand, "@ToAddress", SqlDbType.NVarChar, bookingModel.ToAddress);


                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
