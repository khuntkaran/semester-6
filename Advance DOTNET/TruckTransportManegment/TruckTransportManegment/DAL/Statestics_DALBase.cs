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
                DbCommand dbCommand2 = sqlDatabase.GetStoredProcCommand("PR_Statestics_Timeline");
                List<StatesticsTimeline> statesticsTimelines = new List<StatesticsTimeline>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand2))
                {
                    
                    while (dr.Read())
                    {
                        StatesticsTimeline statesticsTimeline = new StatesticsTimeline();
                        statesticsTimeline.PickUpCityName = dr["PickUpCityName"].ToString();
                        statesticsTimeline.DropCityName = dr["DropCityName"].ToString();
                        statesticsTimeline.TotalOrder = Convert.ToInt32(dr["TotalOrder"].ToString());
                        statesticsTimelines.Add(statesticsTimeline);
                        
                    }

                    statesticsModel.Timeline = statesticsTimelines;
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
