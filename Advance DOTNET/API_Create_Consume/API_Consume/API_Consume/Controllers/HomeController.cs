using API_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace API_Consume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private readonly string apiUrl = "http://localhost:40506/User/"; // Replace with your API URL
        [HttpGet]
        public IActionResult Index()
        {
            List<UserModel> employees = new List<UserModel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response =  client.GetAsync(apiUrl+ "APIUserSelectAll").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonobj = JsonConvert.DeserializeObject(data);
                    var dataofobject = jsonobj.data;
                    var extractedData = JsonConvert.SerializeObject(dataofobject,Formatting.Indented);
                    employees = JsonConvert.DeserializeObject<List<UserModel>>(extractedData);
                }
                else
                {
                    // Handle error response
                    // Example: ViewBag.ErrorMessage = "Failed to fetch employees.";
                }
            }

            return View(employees);
        }

        public IActionResult Privacy(int? id)
        {
            UserModel employee = new UserModel();

            if(id!= null)
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl + "APIUserSelectByPK/"+id).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic jsonobj = JsonConvert.DeserializeObject(data);
                        var dataofobject = jsonobj.data;
                        var extractedData = JsonConvert.SerializeObject(dataofobject, Formatting.Indented);
                        employee = JsonConvert.DeserializeObject<UserModel>(extractedData);
                    }
                    else
                    {
                        // Handle error response
                        // Example: ViewBag.ErrorMessage = "Failed to fetch employees.";
                    }
                }
            }
            return View(employee);
        }

        public IActionResult Save(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                MultipartFormDataContent dataContent = new MultipartFormDataContent();
               
                dataContent.Add(new StringContent(userModel.EmpName));
                dataContent.Add(new StringContent(userModel.EmpCode));
                dataContent.Add(new StringContent(userModel.Email));
                dataContent.Add(new StringContent(userModel.Contact));
                dataContent.Add(new StringContent(userModel.Salary.ToString()));
                using (HttpClient client = new HttpClient())
                {
                    if (userModel.EmpID != null)
                    {
                        dataContent.Add(new StringContent(userModel.EmpID.ToString()));
                        HttpResponseMessage response = client.PutAsync(apiUrl + "APIUserUpdateByPK",dataContent ).Result;
                    }
                    else
                    {
                        HttpResponseMessage response = client.PostAsync(apiUrl + "APIUserInsert", dataContent).Result;
                    }
                    
                }
               

            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteData(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(apiUrl + "APIUserDeleteByPK/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Delete Data
                }
                else
                {
                    // Handle error response
                    // Example: ViewBag.ErrorMessage = "Failed to fetch employees.";
                }
            }

            return RedirectToAction("Index");

        }




















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}