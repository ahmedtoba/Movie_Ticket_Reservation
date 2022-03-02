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
        //show all Cinemas--------------
        public IActionResult Index()
        {
            List<Cinema> cinemas = cinemaRepo.GetAll();
            return View("AllCinemas", cinemas);
        }
        //-----------------------------
        //Cinema Details By link Read more 
        public IActionResult Cinema(int id)
        {
            Cinema cinema = cinemaRepo.GetById(id);
            return View(cinema);
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
        //[admin Section]===========
        //insert From---------------------------------
        public IActionResult InsertForm()
        {
            return View("Cinema_Update_Form");
        }
        //insert---------------------------------
        public IActionResult InsertCinema(Cinema InsertCinema)
        {
            cinemaRepo.insert(InsertCinema);
            return View("Cinema");//Retrun to Details
        }
        //Update From---------------------------------
        public IActionResult UpdateForm()
        {
            return View("Cinema_Update_Form");
        }
        //Update---------------------------------
        public IActionResult UpdateCinema(Cinema EditCin , int id)
        {
            cinemaRepo.update(EditCin, id);
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
