using Microsoft.AspNetCore.Mvc;

namespace shift6.Controllers
{
    public class StateExamplesController : Controller
    {
        public IActionResult Index()  //action
        {
            // view data
            ViewData["username"] = "Ali Jama";
            ViewData["role"] = "Admin & Finance";

            //viewbag
            ViewBag.msg = "Welcome to State Management Examples";
            return View();
        }

       
    }
}
