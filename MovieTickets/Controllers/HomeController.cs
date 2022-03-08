using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IActorRepository actorService;
        private readonly ICategoryRepository categoryService;
        private readonly ICinemaRepository cinemaService;
        private readonly IMovieRepository movieServie;
        private readonly UserManager<User> userService;

        public HomeController(ILogger<HomeController> logger,IActorRepository ActorService, 
            ICategoryRepository CategoryService,ICinemaRepository CinemaService,
            IMovieRepository MovieServie, UserManager<User> userService)
        {
            _logger = logger;
            actorService = ActorService;
            categoryService = CategoryService;
            cinemaService = CinemaService;
            movieServie = MovieServie;
            this.userService = userService;
        }

        public async Task< IActionResult> Index()
        {
            string id = HttpContext.Session.GetString("id");
            HomeViewModel addHome = new HomeViewModel()
            {
                user =await userService.FindByIdAsync(id),
                Cinemas = cinemaService.GetAll(),
                Movies = movieServie.GetAll(),
                Categories = categoryService.GetAll(),
                Actors = actorService.GetAll()
            };
            return PartialView(addHome);
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

        [Authorize(Roles ="Admin")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
