using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using TruckTransportManegment.Areas.Login.Models;

namespace TruckTransportManegment.DAL
{
    public class Login_DALBase
    {
        public UserModel Login(string username, string password)
        {
            try
            {
                int id = 0;
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_User_Select_By_Username_Password");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.NVarChar, username);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.NVarChar, password);
                Console.WriteLine(username, password);
                UserModel userModel= new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    
                        id = Convert.ToInt32(dr["UserID"].ToString());
                        userModel = new UserModel();
                        userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        userModel.UserName = dr["UserName"].ToString();
                        userModel.Phone = dr["Phone"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModel.Password = dr["Password"].ToString();
                        userModel.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                        userModel.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                        userModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                        userModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Registration(UserModel user)
        {
            try
            {
                int id = 0;
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_MST_User_Insert");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.NVarChar, user.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.NVarChar, user.Password);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, user.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Phone", SqlDbType.NVarChar, user.Phone);

                return Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand));
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
