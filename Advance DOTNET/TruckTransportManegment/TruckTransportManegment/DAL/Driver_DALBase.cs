using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;
using TruckTransportManegment.DAL;

namespace DriverTransportManegment.DAL
{
    public class Driver_DALBase
    {
        public bool Driver_AddEdit(DriverModel driverModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand;
                if (driverModel.DriverID != null)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Driver_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@DriverID", SqlDbType.NVarChar, driverModel.DriverID);
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Driver_Insert");
                }
                sqlDatabase.AddInParameter(dbCommand, "@DriverName", SqlDbType.NVarChar, driverModel.DriverName);
                sqlDatabase.AddInParameter(dbCommand, "@DriverPhone", SqlDbType.NVarChar, driverModel.DriverPhone);
                sqlDatabase.AddInParameter(dbCommand, "@LicenceNo", SqlDbType.NVarChar, driverModel.LicenceNo);
                sqlDatabase.AddInParameter(dbCommand, "@LicenceExpiryDate", SqlDbType.DateTime, driverModel.LicenceExpiryDate);


                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<DriverModel> Driver_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Driver_SelectAll");
                List<DriverModel> driverModels = new List<DriverModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        DriverModel driverModel = new DriverModel();
                        driverModel.DriverID = Convert.ToInt32(dr["DriverID"].ToString());
                        driverModel.DriverName = dr["DriverName"].ToString();
                        driverModel.DriverPhone = dr["DriverPhone"].ToString();
                        driverModel.LicenceNo = dr["LicenceNo"].ToString();
                        driverModel.LicenceExpiryDate = Convert.ToDateTime(dr["LicenceExpiryDate"].ToString());
                        driverModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        driverModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        driverModels.Add(driverModel);
                    }
                }
                return driverModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DriverModel Driver_SelectByID(int Driver_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Driver_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@DriverID", SqlDbType.NVarChar, Driver_ID);
                DriverModel driverModel = new DriverModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        driverModel.DriverID = Convert.ToInt32(dr["DriverID"].ToString());
                        driverModel.DriverName = dr["DriverName"].ToString();
                        driverModel.DriverPhone = dr["DriverPhone"].ToString();
                        driverModel.LicenceNo = dr["LicenceNo"].ToString();
                        driverModel.LicenceExpiryDate = Convert.ToDateTime(dr["LicenceExpiryDate"].ToString());
                        driverModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        driverModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                    }
                }
                return driverModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Driver_Delete(int Driver_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Driver_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@DriverID", SqlDbType.NVarChar, Driver_ID);
                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
