using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.MainPages.Models;

namespace TruckTransportManegment.DAL
{
    public class GoodsType_DALBase
    {
        public bool GoodsType_AddEdit(GoodsTypeModel goodsTypeModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand;
                if (goodsTypeModel.GoodsTypeID != null)
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_GoodsType_Update");
                    sqlDatabase.AddInParameter(dbCommand, "@GoodsTypeID", SqlDbType.NVarChar, goodsTypeModel.GoodsTypeID);
                }
                else
                {
                    dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_GoodsType_Insert");
                }
                sqlDatabase.AddInParameter(dbCommand, "@GoodsTypeName", SqlDbType.NVarChar, goodsTypeModel.GoodsTypeName);
                
                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GoodsTypeModel> GoodsType_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_GoodsType_SelectAll");
                List<GoodsTypeModel> goodsTypeModels = new List<GoodsTypeModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        GoodsTypeModel goodsTypeModel = new GoodsTypeModel();
                        goodsTypeModel.GoodsTypeID = Convert.ToInt32(dr["GoodsTypeID"].ToString());
                        goodsTypeModel.GoodsTypeName = dr["GoodsTypeName"].ToString();
                        goodsTypeModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        goodsTypeModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                        goodsTypeModels.Add(goodsTypeModel);
                    }
                }
                return goodsTypeModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public GoodsTypeModel GoodsType_SelectByID(int GoodsType_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString); 
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_GoodsType_SelectByID");
                sqlDatabase.AddInParameter(dbCommand, "@GoodsTypeID", SqlDbType.NVarChar, GoodsType_ID);
                GoodsTypeModel goodsTypeModel = new GoodsTypeModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {

                        goodsTypeModel.GoodsTypeID = Convert.ToInt32(dr["GoodsTypeID"].ToString());
                        goodsTypeModel.GoodsTypeName = dr["GoodsTypeName"].ToString();
                        goodsTypeModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        goodsTypeModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                    }
                }
                return goodsTypeModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool GoodsType_Delete(int GoodsType_ID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_GoodsType_Delete");
                sqlDatabase.AddInParameter(dbCommand, "@GoodsTypeID", SqlDbType.NVarChar, GoodsType_ID);
                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
