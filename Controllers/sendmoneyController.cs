using Microsoft.AspNetCore.Mvc;
using shift6.Models;

namespace shift6.Controllers
{
    public class sendmoneyController : Controller
    {
        public IActionResult send()
        {
            deposit emptymodel=new deposit();
            return View(emptymodel);    
        }

        [HttpPost]
        public IActionResult confirm(deposit model)
        {
            return View(model);
        }
    }
}
