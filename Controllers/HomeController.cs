using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shift6.Models;
using System.Diagnostics;

namespace shift6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("username")==null)
            {
                return RedirectToAction("Login", "Accounts");
            }


            return View();
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

        public IActionResult LayoutExample()
        {
            return View();
        }
        public IActionResult LayoutExample2()
        {
            return View();
        }

        public IActionResult details() 
        {
            string xisbi = Convert.ToString(Request.Query["xisbi"]);
            int tirada = Convert.ToInt32(Request.Query["tirada"]);
            ViewData["xisbi"]=xisbi;
            ViewData["tirada"] = tirada;
            return View();
        }

        public IActionResult storeinsession()
        {
            var v = Request.Query["user"].ToString();
            HttpContext.Session.SetString("username", v);
            return RedirectToAction("displaysession");
        }

        public IActionResult displaysession()
        {
            
            string x = HttpContext.Session.GetString("username");
            return Content($"Your session variable contains this: {x}");
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("displaysession");
        }
    }
}