using Microsoft.AspNetCore.Mvc;

namespace shift6.Controllers
{
    public class teacherController : Controller
    {

        [Route("iskawaran")]   //attribute based routing []
        [Route("api/dahabshiil")]
        [Route("api/telesom")]
        public string salaan()  //action
        {
            return "ASC, Maalin wanaagsan";
        }

        public string yourname()
        {
            return "My name is Ahmed Jama";
        }

        public string findName(int id)
        {
            string result = "";
            if (id == 10)
            {
                result = "Teacher Name: Ahmed Ibrahim";
            }else if(id == 20)
            {
                result = "Teacher Name: Amina Ibrahim";
            }
            else
            {
                result = "Invalid ID No";
            }

            return result;
        }


       
    }
}
