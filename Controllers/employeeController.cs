using Microsoft.AspNetCore.Mvc;
using shift6.Models;
using shift6.Repository;

namespace shift6.Controllers
{
    public class employeeController : Controller
    {
        employeeRepository repo;
        public employeeController()
        {
            repo = new employeeRepository();
        }
        public IActionResult Index()
        {
            var data = repo.getAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(employee model)
        {
            repo.create(model.name, model.phone);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Edit(employee model)
        {
            repo.update(model.id, model.name, model.phone);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Delete(employee model)
        {

            repo.delete(model.id);
            return RedirectToAction("Index");
        }

    }
}
