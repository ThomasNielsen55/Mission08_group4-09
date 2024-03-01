using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_group4_09.Models;
using System.Diagnostics;

namespace Mission08_group4_09.Controllers
{
    public class HomeController : Controller
    {

        private HabitContext _context;

        public HomeController(HabitContext task)
        {
            _context = task;
        }

        public IActionResult Index()
        {   

            return View("Quadrants");
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.categories = _context.Categories.ToList();

            return View("AddEdit", new ToDoList());
        }
        [HttpPost]
        public IActionResult AddEdit(ToDoList t)
        {
            if (t.CategoryId == null)
            {
                ViewBag.categories = _context.Categories.ToList();
                return View(t);
            }
            if (ModelState.IsValid)
            {
                _context.ToDoLists.Add(t);
                _context.SaveChanges();

                return View("Quadrants");
            }
            else
            {
                ViewBag.categories = _context.Categories.ToList();
                return View(t);
            }
        }
        public IActionResult ShowMovies()
        {
            var items = _context.ToDoLists.Include("Category").ToList();

            return View(items);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _context.ToDoLists
                .Single(x => x.TaskId == id);

            return View("AddEdit", record);
        }
        [HttpPost]
        public IActionResult Edit(ToDoList updated)
        {
            _context.Update(updated);
            _context.SaveChanges();
            return RedirectToAction("Quadrants");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _context.ToDoLists
                .Single(x => x.TaskId == id);

            return View(record);
        }
        [HttpPost]
        public IActionResult Delete(ToDoList record)
        {
            _context.ToDoLists.Remove(record);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
