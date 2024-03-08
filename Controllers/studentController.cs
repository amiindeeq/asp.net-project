using Microsoft.AspNetCore.Mvc;
using shift6.Models;

namespace shift6.Controllers
{
    public class studentController : Controller
    {
        //now i am creating new action to dispaly student info
        public IActionResult getStudent()
        {
            student objname = new student();
            objname.id= 1;
            objname.name = "Abdi Jama";
            objname.email = "abdi@gmail.com";
            
            return View(objname); //sending model

        }

        //[NonAction]  //non action selection
        [ActionName("raadi")]
        [HttpGet]
        public  IActionResult findall()
        {
            List<student> students = new List<student>();
            students.Add(new student() { id = 1, name="Ali Omer", email="Ali@gmail.com" });
            students.Add(new student() { id = 2, name = "Fadumo Omer", email = "Ali@gmail.com" });
            students.Add(new student() { id = 3, name = "Ali Ibrahim", email = "Ali@gmail.com" });
            students.Add(new student() { id = 4, name = "Fadumo Ibrahim", email = "Ali@gmail.com" });

            return View(students);


        }


        [NonAction]
        public int calculateBill()
        {
            findall();
            //read all invoices form db
            int intotal = 2500;

            //read receipt from db
            int rece = 1500;

            return intotal - rece;
        }

        public IActionResult newstudent()
        {
            student student = new student();    

            return View(student);
        }
    }
}
