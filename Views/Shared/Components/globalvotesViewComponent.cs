using Microsoft.AspNetCore.Mvc;
using shift6.Models;

namespace shift6.Views.Shared.Components
{
    public class globalvotesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //database communication
            //send email
            //if conditions
            //for(var i=0; i<10; i++)
            //{
            //    //do something
            //}
            List<voteresults> _model = new List<voteresults>();
            _model.Add(new voteresults() { party="Wadani", percent=40 });
            _model.Add(new voteresults() { party = "Kulmiye", percent = 40 });
            _model.Add(new voteresults() { party = "Ucid", percent = 40 });

            return View("Default",_model);
        }
    }
}
