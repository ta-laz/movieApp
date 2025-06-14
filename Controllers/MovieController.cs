using Microsoft.AspNetCore.Mvc;             // this is like the flask equivalent, also where : Controller from later is brought in
using movieApp.Models;                      //this is where our movie class from Models comes in 
using System.Collections.Generic;           // I think this is what allows me to save movies as an array instead of database 
using System.Linq;                          // adds some additional functions (LINQ = language integrated query)
using movieApp.Data;


namespace movieApp.Controllers
{
    public class MovieController : Controller           // the :Controller bit brings in parts from the base class Controller 
    {
        // private static List<Movie> movies = new List<Movie>        //List<> is just the C# syntax to make a list
        // {
        //     new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", Synopsis = "Get from wiki"},
        //     new Movie { Id = 2, Title = "The Matrix", Director = "The Wachowskis", Synopsis = "Get from wiki" }
        // };
        private readonly AppDbContext _context;

        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()        //I think IActionResult here is what causes a return of a webpage
        {
            return View();

            //“Find the view file called Index.cshtml, and give it the _movies list to display.”
        }
        // worth noting on above that the View() is built in and it looks into the Views folder:
        // Look in the Views/ folder
        // Look for a subfolder named after your controller (Movie)
        // Look for a file named after your action (Index.cshtml, Details.cshtml, etc.)
        // Pass the someData to the .cshtml file as the @model

        public IActionResult MovieList()
        {
            var movies = _context.Movies.ToList(); // turn it into a real list
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Random()
        {
            var allMovies = _context.Movies.ToList(); // Pulls all movies into memory
            
            if (allMovies.Count == 0)
                return NotFound("No movies in database.");

            Random rng = new();
            int index = rng.Next(allMovies.Count);

            Movie randomMovie = allMovies[index];
            return RedirectToAction("Details", new { id = randomMovie.Id });
        }

        // Show the empty form for the create page now 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handle the submitted form
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("MovieList");
            }

            return View(movie);
        }
    }
}


