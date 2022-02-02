using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _MovieContext { get; set; }
        public HomeController(MovieFormContext MovieForm)
        {
       
            _MovieContext = MovieForm;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Podcasts is the action connected to the index page. 
        //the View returns the html page we want to view. Name different for communication
        //If the action is the same name as the html, you don't need to add the name in the View
        public IActionResult Podcasts()
        {
            return View("Podcast");
        }

        [HttpGet]
        public IActionResult Movie_form()
        {
            ViewBag.Categories = _MovieContext.Categories.ToList();
         
            return View();
        }

        [HttpPost]
        public IActionResult Movie_form(Movie_app_response mar)
        {
            if (ModelState.IsValid)
            {
                _MovieContext.Add(mar);
                _MovieContext.SaveChanges();

                return View("Conformation", mar);
            }
            else
            {
                ViewBag.Categories = _MovieContext.Categories.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult DisplayMovies()
        {
            var applications = _MovieContext.Responses
                .Include( i => i.Category)
                .ToList();
            return View(applications);
        }

        [HttpGet]
       public IActionResult Edit (int movieID)
        {
            ViewBag.Categories = _MovieContext.Categories.ToList();

            var edit_app = _MovieContext.Responses.Single(i => i.MovieID == movieID);

            return View("Movie_form", edit_app);
        }
        
        [HttpPost]
        public IActionResult Edit (Movie_app_response ed)
        {
            _MovieContext.Update(ed);
            _MovieContext.SaveChanges();

            return RedirectToAction("DisplayMovies");
        }

        [HttpGet]
        public IActionResult Delete (int movieID )
        {
            var delete_app = _MovieContext.Responses.Single(i => i.MovieID == movieID);

            return View(delete_app);
        }

        [HttpPost]
        public IActionResult Delete (Movie_app_response map)
        {
            _MovieContext.Responses.Remove(map);
            _MovieContext.SaveChanges();

            return RedirectToAction("DisplayMovies");
        }
    }
}
