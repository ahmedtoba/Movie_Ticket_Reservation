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

        public CinemaController(ICinemaRepository _cinemaRepo, MovieContext _db,IMovieInCinemaRepository movieInCinemaService)
        {
            cinemaRepo = _cinemaRepo;
            db = _db;
            this.movieInCinemaService = movieInCinemaService;
        }
        //show all Cinemas User View--------------
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AllCinemas", cinemas);
        }
        //show all Cinemas User View--------------
        [Authorize(Roles = "Admin")]
        public IActionResult AdminCinemas()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AdminCinemas", cinemas);
        }
        //-----------------------------
        //Cinema Details By link Read more User 
        public IActionResult Cinema(int id)
        {
            MovieCinemaViewModel cinema = new MovieCinemaViewModel()
            {
                Cinema = cinemaRepo.GetById(id),
                Movies = movieInCinemaService.GetAll().Where(w => w.Id == id).ToList(),
            };
           
            return View("CinemaUserDetails", cinema);
        }
        //Cinema Details By link Read more Admin
        [Authorize(Roles = "Admin")]
        public IActionResult CinemaDetailsAdmin(int id)
        {
            Cinema cinema = cinemaRepo.GetById(id);
            return View("CinemaDetailsAdmin", cinema);
        }
        //-------------------------------
        //for searcing by name-----------
        public IActionResult CinemaName(string name)
        {
            Cinema cinema = cinemaRepo.GetByName(name);
            return View(cinema);
        }
        //------------------------------
        //for searcing by Location-----------
        public IActionResult CinemaLocation(string location)
        {
            Cinema cinema = cinemaRepo.GetByLocation(location);
            return View(cinema);
        }
        //[admin Section]=========================================================
        //insert From---------------------------------
        [Authorize(Roles = "Admin")]
        public IActionResult InsertForm()
        {

            return View("Cinema_Insert_Form", new Cinema());
        }
        //insert---------------------------------
        [Authorize(Roles = "Admin")]
        public IActionResult InsertCinema(Cinema InsertCinema, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.insert(InsertCinema, Image);
                return RedirectToAction("AdminCinemas");
            }
            return RedirectToAction("InsertForm", InsertCinema);
            //Retrun to Details
        }
        //Update From---------------------------------
        public IActionResult UpdateForm(int id)
        {

            Cinema cinema = cinemaRepo.GetById(id);
            return View("CinemaUpdateForm", cinema);
        }
        //Update---------------------------------
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCinema(Cinema EditCin, int id, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                cinemaRepo.update(EditCin, id, Image);
                return RedirectToAction("AdminCinemas");
            }
            return View("CinemaUpdateForm", EditCin);//Retrun to Details
        }
        //------------------------------------------
        //Delete----------------------------------
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            cinemaRepo.delete(id);
            return RedirectToAction("AdminCinemas");
        }
        //Searching by name or location----------------------------
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
    }
}
