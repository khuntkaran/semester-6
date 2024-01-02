using API_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly string apiUrl = "http://localhost:40506/User/APIUserSelectAll"; // Replace with your API URL

        public async Task<IActionResult> IndexAsync()
        {
            List<UserModel> employees = new List<UserModel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonobj = JsonConvert.DeserializeObject(data);
                    var dataofobject = jsonobj.data;
                    employees = JsonConvert.DeserializeObject<List<UserModel>>(dataofobject.data);
                }
                else
                {
                    // Handle error response
                    // Example: ViewBag.ErrorMessage = "Failed to fetch employees.";
                }
            }

            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}