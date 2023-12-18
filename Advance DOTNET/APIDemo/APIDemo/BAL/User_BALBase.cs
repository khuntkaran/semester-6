using APIDemo.DAL;
using APIDemo.Models;

namespace APIDemo.BAL
{
    public class User_BALBase
    {
        public List<UserModel> API_User_SelectAll()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels = user_DALBase.API_User_SelectAll();
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public UserModel API_User_SelectByPK(int id)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                UserModel userModel = user_DALBase.API_User_SelectByPK(id);
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String API_User_DeleteByPK(int id)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                return user_DALBase.API_User_DeleteByPK(id);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
