using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public async Task<IActionResult> Index()
        {
            WeatherData weatherData = new WeatherData();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://api.openweathermap.org/data/2.5/weather?q=India&APPID=201fb22425c00d3f2ebc54bdf9a5c6bc");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                weatherData = JsonConvert.DeserializeObject<WeatherData>(await response.Content.ReadAsStringAsync());
            }
            return View(weatherData);
        }

        public async Task<IActionResult> XMLData()
        {
            WeatherResponsexml weatherResponsexml = new WeatherResponsexml();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://api.openweathermap.org/data/2.5/weather?q=India&APPID=201fb22425c00d3f2ebc54bdf9a5c6bc&mode=xml");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);
                string xml = xdoc.ToString();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
                json = json.Replace("\"@", "\"");
                json = json.Replace("\"#text\"", "\"text\"");
                weatherResponsexml = JsonConvert.DeserializeObject<WeatherResponsexml>(json);
             
                //weatherResponsexml = new JavaScriptSerializer().Deserialize<WeatherResponsexml>(json);
            }
            return View(weatherResponsexml);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
