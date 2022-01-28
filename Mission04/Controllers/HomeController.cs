using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission04.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private MovieFormContext movieContext { get; set; }  // this is to create an instance of the context before linking to the database

        // homecontroller is a constructor, pass teh movie form context to use it
        public HomeController(ILogger<HomeController> logger, MovieFormContext name)
        {
            _logger = logger;
            movieContext = name; // give the context the value of passed parameter
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult My_Podcasts()
        {
            return View();
        }

        [HttpGet] // use this view when
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost] //use this function for a post method like submiting the form, use the object to store and pass along the values from the Form to the view mentioned
        public IActionResult AddMovie(NewMovieForm NM)
        {
            movieContext.Add(NM);
            movieContext.SaveChanges();  // add the contents of the form to the context and then save it to the data base

            return View("Confirmation", NM);  
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}
