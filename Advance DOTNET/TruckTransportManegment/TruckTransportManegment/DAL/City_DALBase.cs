using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;

namespace TruckTransportManegment.DAL
{
    public class City_DALBase
    {
        public bool City_AddEdit(CityModel cityModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand;
                if (cityModel.CityID != null)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_City_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@CityID", SqlDbType.NVarChar, cityModel.CityID);
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_City_Insert");
                }
                sqlDatabase.AddInParameter(dbCommand, "@CityName", SqlDbType.NVarChar, cityModel.CityName);
                sqlDatabase.AddInParameter(dbCommand, "@CityCode", SqlDbType.NVarChar, cityModel.CityCode);


                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CityModel> City_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_City_SelectAll");
                List<CityModel> cityModels = new List<CityModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        CityModel cityModel = new CityModel();
                        cityModel.CityID = Convert.ToInt32(dr["CityID"].ToString());
                        cityModel.CityName = dr["CityName"].ToString();
                        cityModel.CityCode = dr["CityCode"].ToString();
                        cityModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        cityModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        cityModels.Add(cityModel);
                    }
                }
                return cityModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CityModel City_SelectByID(int City_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_City_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@CityID", SqlDbType.NVarChar, City_ID);
                CityModel cityModel = new CityModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        cityModel.CityID = Convert.ToInt32(dr["CityID"].ToString());
                        cityModel.CityName = dr["CityName"].ToString();
                        cityModel.CityCode = dr["CityCode"].ToString();
                        cityModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        cityModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                    }
                }
                return cityModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool City_Delete(int City_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_City_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@CityID", SqlDbType.NVarChar, City_ID);
                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
