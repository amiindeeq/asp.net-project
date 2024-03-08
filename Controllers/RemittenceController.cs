using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using shift6.Models;

namespace shift6.Controllers
{

    [Authorize]
    public class RemittenceController : Controller
    {
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }

        public IActionResult Testing()
        {
            return Content("ASC");
        }

        [HttpPost]
        public IActionResult Create(remittence model)
        {
            string connString = "server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connString))
            {
                string _cuser = HttpContext.Session.GetString("username");
                con.Open();
                string query = $"insert into remittence values('{model.sender}','{model.receiver}',{model.amount},'{model.remarks}','{_cuser}')";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    //data saved
                    ViewData["msg"] = "Congratulation!!, Data saved";
                    return View();
                }
                else
                {
                    //data not saved
                    ViewData["msg"] = "Unable to save data";
                    return View(model);
                }

             


            }
        }
    }
}
