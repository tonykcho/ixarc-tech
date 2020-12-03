using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //var cookies = new CookieContainer();
            //var client = new HttpClient(new HttpClientHandler()
            //{
            //    AllowAutoRedirect = true,
            //    UseCookies = true,
            //    CookieContainer = cookies,
            //});
            //client.DefaultRequestHeaders.
            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Add(".AspNetCore.Cookies", "CfDJ8DgJ8JU_LLhNmOGDUFCg_BB5GMtrmwsqVbsVvSGZrSU1_cD0kYNWNj61IcovBrOSYY89f0-uH-Sopl39_ZUQUgykbmS7579pC1G8yFDHpJwlTIycDl5Vnecd7cYjZD-K8pKliigSKHnrTHfaKepilDhiNPwto1eGYUun-6glwKAJPewRmYcRRhNOcOcirQ6O_HKFv9IoJTqaytIPcVmBgvWzSWFrSlxfPUrvIBJTkuSKNT0NbRjxzsPgrlB7Ey_pcJ6pHYIJERUP3YtjZKgn4mRA9J2Z5wOZ6w1LLOuhIpgEsjaalgeDATA1jTLCx63WhKl50NsgKyxZCnGcHeZqBvtvGSkjmvowihP1pEDZy8YwVwOej901CAzXQDi4KS8M1DFck-7Ux2dHAHwIG18dz4xQ-hxkJ_70vpsMmu0958va2YIXkwN7ZSR388EZce7dfBL6Vs3kxOxHSjUfMXpJsEd4rpnBYmEM3eSd8WB961MdTQECfZJtw5KaR4LwxosQqw");
            var response = client.GetAsync("api/auth/value");
            foreach(var re in response.Result.Headers)
            {
                Console.WriteLine($"{re.Key}, {re.Value.Last()}");
            }
            Console.WriteLine(await response.Result.Content.ReadAsStringAsync());

            //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, )

            var client2 = httpClientFactory.CreateClient();
            var response2 = client2.GetAsync("https://localhost:5011/privacy");
            Console.WriteLine(await response2.Result.Content.ReadAsStringAsync());

            return View();
        }

        [Authorize]
        [Route("privacy")]
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
