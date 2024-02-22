using APIDemo.BAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
        [Route("{id}")]
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
        [Route("{id}")]
        public IActionResult APIUserDeleteByPK(int id)
        {
            User_BALBase user_BALBase = new User_BALBase();
            bool result = user_BALBase.API_User_DeleteByPK(id);
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();
            if (result)
            {
                response.Add("Status", true);
                response.Add("Message", "Delete Data Successful");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("Message", "Error");
                return Ok(response);
            }
            
        }

        [HttpPost]
        public IActionResult APIUserInsert([FromForm]UserModel userModel)
        {
            User_BALBase user_BALBase = new User_BALBase();
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();

            bool result = user_BALBase.API_User_Insert(userModel);
            if (result)
            {
                response.Add("Status", true);
                response.Add("Message", "Insert Data Successful");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("Message", "not inserted --> Error");
                return Ok(response);
            }
        }

        [HttpPut]
        public IActionResult APIUserUpdateByPK([FromForm] UserModel userModel)
        {
            User_BALBase user_BALBase = new User_BALBase();
            bool result = user_BALBase.API_User_UpdateByPK(userModel);
            Dictionary<String, dynamic> response = new Dictionary<string, dynamic>();
            if (result)
            {
                response.Add("Status", true);
                response.Add("Message", "Update Data Successful");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("Message", "Error");
                return Ok(response);
            }
        }

        [HttpPost]
        public IActionResult ProductPost([FromForm] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                return Ok("Data validated successfully!");
            }
            return NotFound("Data not validate!");
        }
    }

}
