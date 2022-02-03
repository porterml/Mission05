using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieFormContext movieContext { get; set; }  // this is to create an instance of the context before linking to the database

        // homecontroller is a constructor, pass teh movie form context to use it
        public HomeController(MovieFormContext name)
        {
            movieContext = name; // give the context the value of passed parameter
        }

        public IActionResult Index() // go to index page
        {
            return View();
        }

        public IActionResult My_Podcasts() // go to my podcasts page
        {
            return View();
        }

        [HttpGet] // use this view when
        public IActionResult AddMovie()
        {
            ViewBag.Categories = movieContext.categories.ToList();   // the word after viewbag could be anything you choose
            // to pass the categories table to the view

            return View(); // viewbag automatically passed
        }

        [HttpPost] //use this function for a post method like submiting the form, use the object to store and pass along the values from the Form to the view mentioned
        public IActionResult AddMovie(NewMovieForm NM)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(NM);
                movieContext.SaveChanges();  // add the contents of the form to the context and then save it to the data base

                return View("Confirmation", NM);
            }
            else  //if invalid
            {
                ViewBag.Categories = movieContext.categories.ToList();

                return View(NM);
            }

        }

        public IActionResult AllMovies() //go to page that lists all movies
        {
            var applications = movieContext.responses
                .Include(x => x.Category)
                //.Where(x => x.Edited == false)
                .OrderBy(x => x.Title)
                .ToList(); //create a list to send to the view so it can be output on the page


            return View(applications); //pass the list to the view via the ()
        }

        [HttpGet]
        public IActionResult Edit (int MovieId) //links to the edit section in the all movies view, Parameter represents specific movie come from html page
        {
            ViewBag.Categories = movieContext.categories.ToList();   // the word after viewbag could be anything you choose

            var movie = movieContext.responses.Single(x => x.MovieId == MovieId);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit (NewMovieForm UM) 
        {
            movieContext.Update(UM);
            movieContext.SaveChanges();

            return RedirectToAction("AllMovies");
        }
        [HttpGet]
        public IActionResult Delete (int MovieId)  //links to the delete section in the all movies view
        {
            var movie = movieContext.responses.Single(x => x.MovieId == MovieId);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete (NewMovieForm DM)
        {
            movieContext.responses.Remove(DM);
            movieContext.SaveChanges();

            return RedirectToAction("AllMovies");
        }
    }

   
}
