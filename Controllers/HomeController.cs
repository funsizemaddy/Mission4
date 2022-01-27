using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext _MovieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieFormContext MovieForm)
        {
            _logger = logger;
            _MovieContext = MovieForm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
        public IActionResult Add_to_Movies()
        {
            return View("Movie_form");
        }

        [HttpPost]
        public IActionResult Add_to_Movies(Movie_app_response mar)
        {
            _MovieContext.Add(mar);
            _MovieContext.SaveChanges();
            return View("Conformation", mar);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
