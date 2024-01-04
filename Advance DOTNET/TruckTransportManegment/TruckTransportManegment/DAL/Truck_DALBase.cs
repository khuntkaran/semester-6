using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;

namespace TruckTransportManegment.DAL
{
    public class Truck_DALBase
    {
        public bool Truck_AddEdit(TruckModel truckModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand;
                if (truckModel.TruckID != null)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Truck_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@TruckID", SqlDbType.NVarChar,truckModel.TruckID);
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Truck_Insert");
                }
                sqlDatabase.AddInParameter(dbCommand, "@TruckName", SqlDbType.NVarChar, truckModel.TruckName);
                sqlDatabase.AddInParameter(dbCommand, "@TruckNumber", SqlDbType.NVarChar, truckModel.TruckNumber);
                sqlDatabase.AddInParameter(dbCommand, "@TruckType", SqlDbType.NVarChar, truckModel.TruckType);
                sqlDatabase.AddInParameter(dbCommand, "@EngineNo", SqlDbType.NVarChar, truckModel.EngineNo);
                sqlDatabase.AddInParameter(dbCommand, "@ChasisNo", SqlDbType.NVarChar, truckModel.ChasisNo);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, truckModel.Price);
                sqlDatabase.AddInParameter(dbCommand, "@Capacity", SqlDbType.Decimal, truckModel.Capacity);

                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TruckModel> Truck_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Truck_SelectAll");
                List<TruckModel> truckModels = new List<TruckModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        TruckModel truckModel = new TruckModel();
                        truckModel.TruckID = Convert.ToInt32(dr["TruckID"].ToString());
                        truckModel.TruckName = dr["TruckName"].ToString();
                        truckModel.TruckType = dr["TruckType"].ToString();
                        truckModel.TruckNumber = dr["TruckNumber"].ToString();
                        truckModel.EngineNo = dr["EngineNo"].ToString();
                        truckModel.ChasisNo = dr["ChasisNo"].ToString();
                        truckModel.Capacity = Convert.ToDouble(dr["Capacity"].ToString());
                        truckModel.Price = Convert.ToDouble(dr["Price"].ToString());
                        truckModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        truckModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        truckModels.Add(truckModel);
                    }
                }
                return truckModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TruckModel Truck_SelectByID(int Truck_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Truck_Select_By_ID");
                sqlDatabase.AddInParameter(dbCommand, "@TruckID", SqlDbType.NVarChar, Truck_ID);
                TruckModel truckModel = new TruckModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        truckModel.TruckID = Convert.ToInt32(dr["TruckID"].ToString());
                        truckModel.TruckName = dr["TruckName"].ToString();
                        truckModel.TruckType = dr["TruckType"].ToString();
                        truckModel.TruckNumber = dr["TruckNumber"].ToString();
                        truckModel.EngineNo = dr["EngineNo"].ToString();
                        truckModel.ChasisNo = dr["ChasisNo"].ToString();
                        truckModel.Capacity = Convert.ToDouble(dr["Capacity"].ToString());
                        truckModel.Price = Convert.ToDouble(dr["Price"].ToString());
                        truckModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        truckModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                    }
                }
                return truckModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Truck_Delete(int Truck_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_Truck_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@TruckID", SqlDbType.NVarChar, Truck_ID);
                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
