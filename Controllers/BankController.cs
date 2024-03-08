using Microsoft.AspNetCore.Mvc;
using shift6.Models;

namespace shift6.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Find()
        {
            ViewData["data_found"] = "0";
            return View();
        }

        [HttpPost]   // action verbs
        public IActionResult Find(account modal)
        {
            account foundmodal = new account(); 
            if(modal.accno== 123)
            {
                foundmodal.name = "Sahal Transport Account";
            }else if (modal.accno == 321)
            {
                foundmodal.name = "Salaama School";
            }

            ViewData["data_found"] = "1";
            return View(foundmodal);
        }

        public IActionResult Register()
        {
            ViewBag.error = null;
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        public IActionResult Register(account modal) 
        {
            string error = "";

            if(modal.accno < 10)
            {
                error = "Invalid Account No";
            }
            else if (modal.name == null)
            {
                error = "Enter Account Name";
            }

            if (error != "")
            {
                ViewBag.error = error;
            }
            else
            {
                ViewBag.error = null;

                //send data to database for saving
                ViewBag.msg = "Data Saved";
            }
            return View(modal);  
        }
    }
}
