using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;

namespace MovieTickets.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaRepository cinemaRepo;
        public CinemaController(ICinemaRepository _cinemaRepo)
        {
            cinemaRepo = _cinemaRepo;
        }
        //show all Cinemas User View--------------
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AllCinemas", cinemas);
        }
        //show all Cinemas User View--------------
        public IActionResult AdminCinemas()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AdminCinemas", cinemas);
        }
        //-----------------------------
        //Cinema Details By link Read more User 
        public IActionResult Cinema(int id)
        {
            Cinema cinema = cinemaRepo.GetById(id);
            return View(cinema);
        }
        //Cinema Details By link Read more Admin
        public IActionResult CinemaDetailsAdmin(int id)
        {
            Cinema cinema = cinemaRepo.GetById(id);
            return View("CinemaDetailsAdmin",cinema);
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
        public IActionResult InsertForm()
        {
            return View("Cinema_Insert_Form");
        }
        //insert---------------------------------
        public IActionResult InsertCinema(Cinema InsertCinema, IFormFile Image)
        {
            cinemaRepo.insert(InsertCinema,Image);
            return View("Cinema");//Retrun to Details
        }
        //Update From---------------------------------
        public IActionResult UpdateForm()
        {
            return View("CinemaUpdateForm");
        }
        //Update---------------------------------
        public IActionResult UpdateCinema(Cinema EditCin , int id, IFormFile Image)
        {
            cinemaRepo.update(EditCin, id, Image);
            return View("Cinema");//Retrun to Details
        }
        //------------------------------------------
        //Delete----------------------------------
        public IActionResult DeleteCinema(int id)
        {
            cinemaRepo.delete(id);
            return View("Index");
        }

    }
}
