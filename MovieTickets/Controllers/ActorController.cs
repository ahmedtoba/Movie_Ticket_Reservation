using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class ActorController : Controller
    {
        IActorRepository actorRepository;
        IMovieRepository movieRepository;
        MovieContext db;
        public ActorController(IActorRepository ActRepo,IMovieRepository MovRepo, MovieContext _db)
        {
            actorRepository= ActRepo;
            movieRepository= MovRepo;
            db= _db;

        }

        //get all actors for users 
        public ActionResult Index()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View( Actors);
        }
        //get all actors for admin
        [Authorize(Roles="Admin")]
        public IActionResult AdminActors()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View("AdminActors", Actors);
        }
        //searching----------------------------------------------

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AdminActors(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var actors = db.Actors.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                actors = actors.Where(c => c.Name.Contains(Keyword));

            }
            return View(await actors.AsNoTracking().ToListAsync());
        }



        public ActionResult Details(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View("DetailsUser", Actors);
        }
        //The details of actors for admin
        [Authorize(Roles = "Admin")]
        public ActionResult ActorsDetailsAdmin(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View("ActorsDetailsAdmin", Actors);
        }

       

        //Details of actors for users---------------------------------- 
        public IActionResult Actor(int id)
        {
            Actor Actor = actorRepository.GetById(id);
            return View(Actor);
        }
        //Searching-------------------------------------
       public ActionResult ActorName(string name)
        {

            Actor Actors = actorRepository.GetByName(name);
            return View(Actors);
        }


        //insert actor
        public IActionResult InsertActorForm()
        {
            return View("InsertActor", new Actor());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Actor NewActor,List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task<int> numOfRowsInsertion = actorRepository.insert(NewActor,Image);
                return RedirectToAction("AdminActors");
            }

            return RedirectToAction("Actor");
        }
        //--------------------------------------------------------------------------
        //public IActionResult InsertActor(Actor InsertActor, IFormFile Image)
        //{
        //    actorRepository.insert(InsertActor, Image);
        //    return View("Actor");
        //}
        public IActionResult UpdateActorForm(int id)
        {
            var actor = actorRepository.GetById(id);

            return View("UpdateActor",actor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor EditActor, int id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                actorRepository.update(EditActor, id, Image);
                return RedirectToAction("AdminActors", "Actor");
            }
            return View("UpdateActor");
           

        }
        //Update actor

        //------------------------------------------------------------
        //public IActionResult UpdateActor(Actor EditActor, int id, IFormFile Image)
        //{
        //    actorRepository.update(EditActor, id, Image);
        //    return View("Actor");
        //}



        //Delete Actor
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            actorRepository.delete(id);
            return RedirectToAction("AdminActors");
        }
    }
}
