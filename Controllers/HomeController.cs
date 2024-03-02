//using AspNetCore;
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
            var tasks = _repo.ToDoLists.ToList();

            return View("Quadrants", tasks);
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
            //if (t.CategoryId == null)
            //{
            //    ViewBag.categories = _repo.Categories.ToList();
            //    return View(t);
            //}
            if (ModelState.IsValid)
            {
                _repo.AddToDoList(t);

                var tasks = _repo.ToDoLists.ToList();

                return View("Quadrants", tasks);
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
            ViewBag.categories = _repo.Categories.ToList();

            var record = _repo.ToDoLists
                .Single(x => x.TaskId == id);

            return View("AddEdit", record);
        }
        [HttpPost]
        public IActionResult Edit(ToDoList updated)
        {
            _repo.UpdateToDoList(updated);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var record = _repo.ToDoLists
                .Single(x => x.TaskId == id);

            _repo.RemoveToDoList(record);

            var tasks = _repo.ToDoLists.ToList();

            return RedirectToAction("Index", tasks);
        }
        [HttpPost]
        public IActionResult Complete(int id)
        {
            
            var record = _repo.ToDoLists
                .Single(x => x.TaskId == id);

            record.Completed = 1;

            var tasks = _repo.ToDoLists.ToList();

            return RedirectToAction("Index", tasks);
        }
       
    }
}
