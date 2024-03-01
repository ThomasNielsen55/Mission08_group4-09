using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_group4_09.Models;
using System.Diagnostics;

namespace Mission08_group4_09.Controllers
{
    public class HomeController : Controller
    {

        private ITaskRepository _repo;

        public HomeController(ITaskRepository task)
        {
            _repo = task;
        }

        public IActionResult Index()
        {   

            return View("Quadrants");
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.categories = _repo.Categories.ToList();

            return View("AddEdit", new ToDoList());
        }
        [HttpPost]
        public IActionResult AddEdit(ToDoList t)
        {
            if (t.CategoryId == null)
            {
                ViewBag.categories = _repo.Categories.ToList();
                return View(t);
            }
            if (ModelState.IsValid)
            {
                _repo.AddToDoList(t);

                return View("Quadrants");
            }
            else
            {
                ViewBag.categories = _repo.Categories.ToList();
                return View(t);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repo.ToDoLists
                .Single(x => x.TaskId == id);

            return View("AddEdit", record);
        }
        [HttpPost]
        public IActionResult Edit(ToDoList updated)
        {
            _repo.UpdateToDoList(updated);
            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _repo.ToDoLists
                .Single(x => x.TaskId == id);

            return View(record);
        }
        [HttpPost]
        public IActionResult Delete(ToDoList record)
        {
            _repo.RemoveToDoList(record);

            return RedirectToAction("Quadrants");
        }
    }
}
