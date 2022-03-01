using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository categoryService;
        private readonly ICinemaRepository cinemaService;
        private readonly IMovieRepository movieServie;

        public HomeController(ILogger<HomeController> logger, ICategoryRepository CategoryService,ICinemaRepository CinemaService,IMovieRepository MovieServie)
        {
            _logger = logger;
            categoryService = CategoryService;
            cinemaService = CinemaService;
            movieServie = MovieServie;
        }

        public IActionResult Index()
        {
           
            HomeViewModel addHome = new HomeViewModel()
            {
                Cinemas = cinemaService.GetAll(),
                Movies = movieServie.GetAll(),
                Categories = categoryService.GetAll()
            };
            return View(addHome);
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
