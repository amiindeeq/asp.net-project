using Microsoft.AspNetCore.Mvc;
using shift6.Models;
using shift6.Repository;

namespace shift6.Controllers
{
    public class teachController : Controller
    {
        teachRepository repo;
        public teachController()
        {
            repo = new teachRepository();
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
        public IActionResult Create(teach model)
        {
            repo.create(model.name, model.c_id, model.e_id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Edit(teach model)
        {
            repo.update(model.id, model.name, model.c_id, model.e_id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var found = repo.get_by_id(id);
            return View(found);
        }

        [HttpPost]
        public IActionResult Delete(teach model)
        {

            repo.delete(model.id);
            return RedirectToAction("Index");
        }


    }
}
