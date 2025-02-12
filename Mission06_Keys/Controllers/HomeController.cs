using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Keys.Models;

namespace Mission06_Keys.Controllers
{
    public class HomeController : Controller
    {
        private MovieEntryContext _context;

        public HomeController(MovieEntryContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddToCollection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCollection(MovieEntry response)
        {
            _context.MovieEntries.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
