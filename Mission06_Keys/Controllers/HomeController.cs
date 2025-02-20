using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Keys.Models;

namespace Mission06_Keys.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp)
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
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryId).ToList();

            return View(new Movie());
        }

        [HttpPost]
        public IActionResult AddToCollection(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryId).ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult MovieCollection()
        {
            var moviesCollection = _context
                .Movies.Include(x => x.Category) // This include method is like a join
                .OrderBy(x => x.Year)
                .ToList();

            return View(moviesCollection);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryId).ToList();

            return View("AddToCollection", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie response)
        {
            _context.Update(response);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            _context.Remove(response);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
    }
}
