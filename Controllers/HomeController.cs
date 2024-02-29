using Microsoft.AspNetCore.Mvc;
using Mission08_group4_09.Models;
using System.Diagnostics;

namespace Mission08_group4_09.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //private TaskClassContext _context;

        //public HomeController(TaskClassContext task)
        //{
        //    _context = task;
        //}

        public IActionResult Index()
        {
            return View("Quadrants");
        }
        public IActionResult Task()
        {
            return View();
        }

        //public IActionResult Quadrants()
        //{
        //    return View();
        //}

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
