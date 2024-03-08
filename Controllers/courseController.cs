using Microsoft.AspNetCore.Mvc;
using shift6.Models;
using shift6.Repository;

namespace shift6.Controllers
{
    public class courseController : Controller
    {
        courseRepository repo;
        public courseController()
        {
            repo = new courseRepository();
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
        public IActionResult Create(course model)
        {
            repo.create(model.name);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Edit(course model)
        {
            repo.update(model.id, model.name);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Delete(course model)
        {

            repo.delete(model.id);
            return RedirectToAction("Index");
        }

    }
}
