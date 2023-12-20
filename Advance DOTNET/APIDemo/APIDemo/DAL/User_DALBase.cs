using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata;

namespace APIDemo.DAL
{
    public class User_DALBase
    {
        public List<UserModel> API_User_SelectAll()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Persion_SelectAll");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserId = Convert.ToInt32(dr["PersionID"].ToString());
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public UserModel API_User_SelectByPK(int id)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Persion_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand,"@ID",SqlDbType.Int, id);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    userModel.UserId = Convert.ToInt32(dr["PersionID"].ToString());
                    userModel.Name = dr["Name"].ToString();
                    userModel.Contact = dr["Contact"].ToString();
                    userModel.Email = dr["Email"].ToString();                    
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool API_User_DeleteByPK(int id)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Persion_DeleteByPK");
                sqlDatabase.AddInParameter(dbCommand, "@ID", SqlDbType.Int, id);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public bool API_User_Insert(String Name,String Email, String Contact)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Persion_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.NVarChar, Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.NVarChar, Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool API_User_UpdateByPK(int id,String Name, String Email, String Contact)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Persion_UpdateByPK");
                sqlDatabase.AddInParameter(dbCommand, "@ID", SqlDbType.Int, id);
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.NVarChar, Name);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.NVarChar, Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, Email);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
