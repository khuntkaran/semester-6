﻿using APIDemo.DAL;
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

        public bool API_User_DeleteByPK(int id)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.API_User_DeleteByPK(id))
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
        public bool API_User_Insert(String Name,  String Email, String Contact)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.API_User_Insert(Name, Email, Contact))
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
                User_DALBase user_DALBase = new User_DALBase();
                if (user_DALBase.API_User_UpdateByPK(id,Name, Email, Contact))
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
