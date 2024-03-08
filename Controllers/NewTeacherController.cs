using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using shift6.Data;
using shift6.Models;

namespace shift6.Controllers
{
    public class NewTeacherController : Controller
    {
        
        // prepare db connect
        private readonly dbContext _dbContext;
        public NewTeacherController(dbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        //create list action
        public IActionResult Index()    //action
        { 
            //"select * from teachers order by id desc"
            var modelData = _dbContext.Teachers
                .OrderByDescending(x => x.Id)   
                .ToList();
            return View(modelData);
        }

        public IActionResult Create()  //http get
        {
            ViewData["uname"] = HttpContext.Session.GetString("username");
            Teacher emptyModel= new Teacher();  
            return View(emptyModel);    
        }
         
        //action verbs
        [HttpPost]
        public IActionResult Create(Teacher model) 
        {
            _dbContext.Teachers.Add(model);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)  //controller/action/id
        {
            var found = _dbContext.Teachers.Find(id);
            return View(found);
        }

        //action verbs
        [HttpPost]
        public IActionResult Edit(Teacher model)
        {
            var found = _dbContext.Teachers.Find(model.Id);
            found.Name=model.Name;
            found.Email=model.Email;    
            found.Mobile=model.Mobile;  
            _dbContext.Teachers.Update(found);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)  //controller/action/id
        {
            var found = _dbContext.Teachers.Find(id);
            return View(found);
        }

        //action verbs
        [HttpPost]
        public IActionResult Delete(Teacher model)
        {
            var found = _dbContext.Teachers.Find(model.Id);
            _dbContext.Teachers.Remove(found);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
