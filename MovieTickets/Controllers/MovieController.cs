using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieContext db;
        IMovieRepository movieRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly ICinemaRepository cinemaRepo;
        private readonly IProducerRepository produerService;
        private readonly IActorRepository actorService;
        private readonly IMovieActorRepository movieactorService;
        private readonly IMovieInCinemaRepository movieincinemaService;
        private readonly ICartRepository cartservice;
        #region Constructor Injection
        public MovieController(MovieContext db, IMovieRepository movieRepo,
            ICategoryRepository categoryRepo, ICinemaRepository cinemaRepo,
            IProducerRepository produerService, IActorRepository actorService,
            IMovieActorRepository movieactorService, IMovieInCinemaRepository movieincinemaService, ICartRepository cartservice)
        {
            this.db = db;
            this.movieRepo = movieRepo;
            this.categoryRepo = categoryRepo;
            this.cinemaRepo = cinemaRepo;
            this.produerService = produerService;
            this.actorService = actorService;
            this.movieactorService = movieactorService;
            this.movieincinemaService = movieincinemaService;
            this.cartservice = cartservice;
        }
        #endregion
        static Guid iid;


        #region User
        #region Index
        public ActionResult Index()
        {


            MovieItemViewModel mivm = new MovieItemViewModel()
            {
                Movies = movieRepo.GetAll(),
                Producers = produerService.GetAll(),
                Cinemas = cinemaRepo.GetAll(),
                Actors = actorService.GetAll(),
                Categories = categoryRepo.GetAll(),
                MovieActors = movieactorService.GetAll()

            };

            return View("IndexUser", mivm);
        }
        #endregion
        #region Details
        public ActionResult Details(Guid id)
        {
            Cart cart = new Cart();
            cart.UserId = HttpContext.Session.GetString("id");
                cart.MovieId=id;


            MovieDetailsViewModel mdvm = new MovieDetailsViewModel()
            {
                UserId = HttpContext.Session.GetString("id"),
                Movie = movieRepo.GetById(id),
                MovieActors = movieactorService.GetAll().Where(w => w.MovieId == id).ToList(),
                MoviesInCinemas = movieincinemaService.GetAll().Where(w => w.MovieId == id).ToList(),
                carts = cartservice.GetData(cart),

            };

            return View("DetailsUser", mdvm);
        }
        #endregion
        #endregion
        #region Admin
        #region Index
        [Authorize(Roles = "Admin")]
        public ActionResult GetMoviesAdmin()
        {
            List<Movie> MovieView = movieRepo.GetAll();

            return View("AdminMovie", MovieView);

        }
        #endregion
        #region Details
        [Authorize(Roles = "Admin")]
        public ActionResult GetMoviesDetailsAdmin(Guid id)

        {
            MovieViewModel Moviemodel = movieRepo.GetMovieByIdAdmin(id);

            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");





            return View("MovieDetailsAdmain", Moviemodel);
        }
        #endregion
        #region Insert
        #region Get
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");

            return View(new MovieViewModel());

        }
        #endregion
        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel movievm, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                movieRepo.Insert(movievm, Image);
                return RedirectToAction("GetMoviesAdmin", "Movie");
            }


            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");
            return View(movievm);

        }
        #endregion
        #endregion
        #region Update
        #region Get
        [Authorize(Roles = "Admin")]
        public ActionResult EditMovieFromAdmin(Guid id)

        {
            iid = id;
            MovieViewModel Moviemodel = movieRepo.GetMovieByIdAdmin(id);

            ViewBag.Cinemas = new SelectList(db.Cinemas.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            ViewBag.Actors = new SelectList(db.Actors.ToList(), "Id", "Name");
            ViewBag.Producers = new SelectList(db.Producers.ToList(), "Id", "Name");



            return View("Edit", Moviemodel);
        }
        #endregion
        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(MovieViewModel editMovie, List<IFormFile> Image)
        {

            Task<int> numOfRowsUpdated = movieRepo.update(editMovie, iid, Image);
            return RedirectToAction("Getmoviesadmin");
        }
        #endregion
        #endregion
        #region Delete
        public ActionResult Delete(Guid id)
        {
            movieRepo.delete(id);
            return RedirectToAction("Getmoviesadmin");

        }

        #endregion
        #endregion
        #region Search
        #region Filter
        [HttpGet]
        public async Task<IActionResult> filterSearch(string MovieName)
        {
            ViewData["MovieName"] = MovieName;

            if (!string.IsNullOrEmpty(MovieName))
            {
                var movies = new MovieItemViewModel()
                {
                    Movies = db.Movies.Where(c => c.Name.Contains(MovieName)).ToList(),
                    Producers = produerService.GetAll(),
                    Cinemas = cinemaRepo.GetAll(),
                    Actors = actorService.GetAll(),
                    Categories = categoryRepo.GetAll(),
                    MovieActors = movieactorService.GetAll()
                };

                //movie = movie;
                return View("IndexUser", movies);


            }
            return Content("nothing");

        }
        #endregion
        #region By Name
        [HttpGet]
        public async Task<IActionResult> movieSearch(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                movies = movies.Where(c => c.Name.Contains(Keyword));

            }
            return View(await movies.AsNoTracking().ToListAsync());
        }

        #endregion
        #region Another Search
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMoviesAdmin(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var movies = db.Movies.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                movies = movies.Where(c => c.Name.Contains(Keyword));

            }
            return View("AdminMovie", await movies.AsNoTracking().ToListAsync());
        }
        #endregion
        #region Add Cinema
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCinema(List<string> cinemas)
        {
            var cinemaNames = new List<string>();
            foreach (string id in cinemas)
            {
                cinemaNames.Add(cinemaRepo.GetById(int.Parse(id)).Name);
            }
            ViewBag.Cinemas = cinemaNames;
            return PartialView("_AddCinema", new MovieViewModel());
        }
        #endregion
        #endregion


        //search by name or actor-------------------


        //searcing--------------------------------------






        // To Get Movie by ID



        //To get Movie by name
        //public ActionResult Details(string name)
        //{
        //    Movie movie = movieRepo.GetByName(name);
        //    return View();
        //}

        // To add new movie
        //get method opening create page




        // post create method




        // To Edit any Movie




        // POST: MovieController/Edit/5



        // To delete movies



        // POST: MovieController/Delete/5


        //partial view for adding quantites of tickets of the movie for each cinema


    }
}
