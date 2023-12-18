﻿using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id:int?}")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult APIUserSelectAll()
        {
            User_BALBase user_BALBase = new User_BALBase();
            List<UserModel> users = user_BALBase.API_User_SelectAll();
            Dictionary<String,dynamic> response = new Dictionary<String,dynamic>();
            if(users != null && users.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpGet]
        public IActionResult APIUserSelectByPK(int id)
        {
            User_BALBase user_BALBase = new User_BALBase();
            UserModel user = user_BALBase.API_User_SelectByPK(id);
            Dictionary<String, dynamic> response = new Dictionary<String, dynamic>();
            if (user != null )
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }

        [HttpDelete]
        public IActionResult APIUserDeleteByPK(int id)
        {
            User_BALBase user_BALBase = new User_BALBase();
            String result = user_BALBase.API_User_DeleteByPK(id);
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();
            response.Add("Status",true);
            response.Add("Result", result);
            return Ok(response);
        }
    }

}
