using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using psi_net_admin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace psi_net_admin.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _urlPrefix;
        private IConfiguration _configuration;

        public UserController(IConfiguration Configuration)
        {
            _configuration = Configuration;
            _urlPrefix = _configuration["UrlPrefix"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_urlPrefix);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<IEnumerable<TechViewModel>> GetTechsAsync()
        {
            var action = "technician/GetPSITechs";
            HttpResponseMessage msg = await _client.GetAsync(action);
            var techs = new List<TechViewModel>();
            if (msg.IsSuccessStatusCode)
            {
                var data = msg.Content.ReadAsStringAsync().Result;
                techs = JsonConvert.DeserializeObject<List<TechViewModel>>(data);
            }
            return techs;
        }
    }
}