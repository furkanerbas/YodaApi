using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using YodaApi.Models;

namespace YodaApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Translate _translate = new Translate();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.funtranslations.com/translate/yoda?text=merhaba%20furkan"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _translate = JsonConvert.DeserializeObject<Translate>(apiResponse);
                }
            }
            return View(_translate);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Text)
        {
            Translate _translate = new Translate();
            using (var httpClient = new HttpClient())
            {
                string apiurl = "http://api.funtranslations.com/translate/yoda?text=" + Text;
                using (var response = await httpClient.GetAsync(apiurl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _translate = JsonConvert.DeserializeObject <Translate>(apiResponse);
                }
            }
            return View(_translate);
        }
    }
    }