using Microsoft.AspNetCore.Mvc;
using shift6.Models;

namespace shift6.Controllers
{
    public class classworkController : Controller
    {
        public IActionResult Details(int id)
        {
            product xx= new product();
            if (id == 1)
            {
                xx.id = 1;
                xx.name = "HP Computer";
                xx.categroy = "Electronics";
                xx.price = 20.5m;
            }
            else
            {
                xx.id = id;
                xx.name = "Mouse";
                xx.categroy = "Electronis";
                xx.price = 1.25m;
            }

       

            return View(xx);
        }
    }
}
