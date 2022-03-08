using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MovieTickets.ViewModels;

namespace MovieTickets.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaRepository cinemaRepo;
        MovieContext db;
        private readonly IMovieInCinemaRepository movieInCinemaService;
        #region Constructor Injection
        public CinemaController(ICinemaRepository _cinemaRepo, MovieContext _db,IMovieInCinemaRepository movieInCinemaService)
        {
            cinemaRepo = _cinemaRepo;
            db = _db;
            this.movieInCinemaService = movieInCinemaService;
        }
        #endregion
 
        #region User
        #region Index
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AllCinemas", cinemas);
        }
        #endregion
        #region Details
        public IActionResult Cinema(int id)
        {
            MovieCinemaViewModel cinema = new MovieCinemaViewModel()
            {
                Cinema = cinemaRepo.GetById(id),
                Movies = movieInCinemaService.GetAll().Where(w => w.Cinema.Id == id).ToList(),
            };

            return View("CinemaUserDetails", cinema);
        }
        #endregion
        #endregion

        #region Admin
        #region Index
        [Authorize(Roles = "Admin")]
        public IActionResult AdminCinemas()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AdminCinemas", cinemas);
        }
        #endregion
        #region Details
        [Authorize(Roles = "Admin")]
        public IActionResult CinemaDetailsAdmin(int id)
        {
            Cinema cinema = cinemaRepo.GetById(id);
            return View("CinemaDetailsAdmin", cinema);
        }
        #endregion
        #region Insert
        #region Get
        [Authorize(Roles = "Admin")]
        public IActionResult InsertForm()
        {

            return View("Cinema_Insert_Form", new Cinema());
        }


        #endregion
        #region Post
        [Authorize(Roles = "Admin")]
        public IActionResult InsertCinema(Cinema InsertCinema, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.insert(InsertCinema, Image);
                return RedirectToAction("AdminCinemas");
            }
            return RedirectToAction("InsertForm", InsertCinema);
            //Retrun to Details
        }
        #endregion

        #endregion
        #region Update

        #region Get
        public IActionResult UpdateForm(int id)
        {

            Cinema cinema = cinemaRepo.GetById(id);
            return View("CinemaUpdateForm", cinema);
        }


        #endregion
        #region Post
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCinema(Cinema EditCin, int id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.update(EditCin, id, Image);
                return RedirectToAction("AdminCinemas");
            }
            return View("CinemaUpdateForm", EditCin);//Retrun to Details
        }
        #endregion

        #endregion

        #region Delete
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            cinemaRepo.delete(id);
            return RedirectToAction("AdminCinemas");
        }
        #endregion

        #endregion
        #region Search
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminCinemas(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var cinemas = db.Cinemas.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                cinemas = cinemas.Where(c => c.Name.Contains(Keyword) || c.Location.Contains(Keyword));

            }
            return View(await cinemas.AsNoTracking().ToListAsync());
        }
        #endregion

        #region GetCinemaByNmae
        public IActionResult CinemaName(string name)
        {
            Cinema cinema = cinemaRepo.GetByName(name);
            return View(cinema);
        }
        #endregion
        #region GetcinemaByLocation
        public IActionResult CinemaLocation(string location)
        {
            Cinema cinema = cinemaRepo.GetByLocation(location);
            return View(cinema);
        }
        #endregion
       
    }
}
