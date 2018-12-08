using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AssetTracking.BLL;
using AssetTracking.BLL.interfaces;
using AssetTracking.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AssetTracking.App.Controllers
{
    public class EmployeeController : Controller
    {
        IAssetManager AssetManager { get; set; }

        HttpClient Client;
        string URL = "https://localhost:44383/api/Employee";

        public EmployeeController(IAssetManager manager)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(URL);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AssetManager = manager;

        }

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage msg = await Client.GetAsync(URL);
            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                var employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                return View(employees);
            }
            return RedirectToAction("Error", "Home");
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            HttpResponseMessage msg = await Client.GetAsync(URL);
            var employees = new List<Employee>();
            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return employees;
        }

        public async Task<ActionResult> Assignment()
        {
            HttpResponseMessage msg = await Client.GetAsync(URL);
            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                var employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                var assets = AssetManager.GetAll();
                var list = employees.Where(e => !assets.Any(a => a.AssignedTo == e.EmployeeNumber)).
                            ToList();
                return View(list);
            }
            return RedirectToAction("Error", "Home");
        }

    }
}