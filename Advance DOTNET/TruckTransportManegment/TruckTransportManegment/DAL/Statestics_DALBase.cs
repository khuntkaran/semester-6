using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;

namespace TruckTransportManegment.DAL
{
    public class Statestics_DALBase
    {
        public StatesticsModel Statestics_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Statestics_All");
                StatesticsModel statesticsModel = new StatesticsModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        statesticsModel.TruckCount= Convert.ToInt32(dr["TruckCount"].ToString());
                        statesticsModel.OrderCount = Convert.ToInt32(dr["OrderCount"].ToString());
                        statesticsModel.DriverCount = Convert.ToInt32(dr["DriverCount"].ToString());
                        statesticsModel.UserCount = Convert.ToInt32(dr["UserCount"].ToString());

                    }
                }
                return statesticsModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
