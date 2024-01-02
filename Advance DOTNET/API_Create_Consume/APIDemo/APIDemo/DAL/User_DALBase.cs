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
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("GetAll");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.EmpID = Convert.ToInt32(dr["EmpID"].ToString());
                        userModel.EmpName = dr["EmpName"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModel.EmpCode = dr["EmpCode"].ToString();
                        userModel.Salary = Convert.ToDouble(dr["Salary"].ToString());
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
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("GetEmployeeById");
                sqlDatabase.AddInParameter(dbCommand,"@EmpID",SqlDbType.Int, id);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dr.Read();
                    userModel.EmpID = Convert.ToInt32(dr["EmpID"].ToString());
                    userModel.EmpName = dr["EmpName"].ToString();
                    userModel.Contact = dr["Contact"].ToString();
                    userModel.Email = dr["Email"].ToString();
                    userModel.EmpCode = dr["EmpCode"].ToString();
                    userModel.Salary = Convert.ToDouble(dr[ "Salary"].ToString());
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
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("DeleteEmployee");
                sqlDatabase.AddInParameter(dbCommand, "@EmpID", SqlDbType.Int, id);
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
        
        public bool API_User_Insert(UserModel userModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("InsertEmployee");
                sqlDatabase.AddInParameter(dbCommand, "@EmpName", SqlDbType.NVarChar, userModel.EmpName) ;
                sqlDatabase.AddInParameter(dbCommand, "@EmpCode", SqlDbType.NVarChar, userModel.EmpCode);
                sqlDatabase.AddInParameter(dbCommand, "@Salary", SqlDbType.Decimal, userModel.Salary);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.NVarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, userModel.Email);
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

        public bool API_User_UpdateByPK(UserModel userModel)
        {
            try
                {
                SqlDatabase sqlDatabase = new SqlDatabase(DAL_Helpers.ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("UpdateEmployee");
                sqlDatabase.AddInParameter(dbCommand, "@EmpID", SqlDbType.Int, userModel.EmpID);
                sqlDatabase.AddInParameter(dbCommand, "@EmpName", SqlDbType.NVarChar, userModel.EmpName);
                sqlDatabase.AddInParameter(dbCommand, "@EmpCode", SqlDbType.NVarChar, userModel.EmpCode);
                sqlDatabase.AddInParameter(dbCommand, "@Salary", SqlDbType.Decimal, userModel.Salary);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.NVarChar, userModel.Contact);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.NVarChar, userModel.Email);
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
