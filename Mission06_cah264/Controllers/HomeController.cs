using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_cah264.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Controller page. This page is what brings us routes us to all actions and pages.
namespace Mission06_cah264.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext daContext { get; set; }

        //private readonly ILogger<HomeController> _logger;

        public HomeController(MovieContext someName)
        {

            daContext = someName;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        //Form get and post. To retrieve information then actually push it on the form.
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        // Helping the form using categories as a foreign key relationship
        [HttpPost]
        public IActionResult Form(FormResponse response)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(response);
                daContext.SaveChanges();

                return View("Confirmation", response);
            }

            else
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View(response);
            }
            
        }
        //This is to list the movies on a page where you can see and edit the database
        [HttpGet]
        public IActionResult ListMovies()
        {
            var applications = daContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }
        //Editing section.
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.responses.Single(x => x.MovieID == movieid);

            return View("Form", application);
        }
        [HttpPost]
        public IActionResult Edit(FormResponse response)
        {
            daContext.Update(response);
            daContext.SaveChanges();

            return RedirectToAction("ListMovies");
        }
        //Deleting section.
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = daContext.responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(FormResponse response)
        {
            daContext.responses.Remove(response);
            daContext.SaveChanges();

            return RedirectToAction("ListMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
