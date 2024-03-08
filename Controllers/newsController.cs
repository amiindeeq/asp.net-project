using Microsoft.AspNetCore.Mvc;

namespace shift6.Controllers
{
    public class newsController : Controller
    {
        public string find(int id)
        {
            string newsdata = "";
            if (id == 1)
            {
                newsdata = "There is Jihaad between israel and palestine";
            }
            else if(id== 2) {
                newsdata = "S/land goverment has openned new office buidlindings";
            }
            else
            {
                newsdata = "Invalid ID No";
            }
            return newsdata;
        }
    }
}
