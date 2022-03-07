using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class ActorController : Controller
    {
        IActorRepository actorRepository;
        IMovieRepository movieRepository;
        public ActorController(IActorRepository ActRepo,IMovieRepository MovRepo)
        {
            actorRepository= ActRepo;
            movieRepository= MovRepo;

        }

        //get all actors for users 
        public ActionResult Index()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View( Actors);
        }
        //get all actors for admin
        public IActionResult AdminActors()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View("AdminActors", Actors);
        }


        public ActionResult Details(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View("DetailsUser", Actors);
        }
        //The details of actors for admin
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
            return View("InsertActorForm");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor NewActor,List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task<int> numOfRowsInsertion = actorRepository.insert(NewActor,Image);
                return View();
            }

            return RedirectToAction("Actor");
        }
        //--------------------------------------------------------------------------
        //public IActionResult InsertActor(Actor InsertActor, IFormFile Image)
        //{
        //    actorRepository.insert(InsertActor, Image);
        //    return View("Actor");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor EditActor, int id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task<int> numOfRowsUpdated = actorRepository.update(EditActor, id, Image);
                return View();
            }
            return RedirectToAction("Actor");

        }
        //Update actor
        public IActionResult UpdateActorForm()
        {
            return View("UpdateActorForm");
        }
        //------------------------------------------------------------
        //public IActionResult UpdateActor(Actor EditActor, int id, IFormFile Image)
        //{
        //    actorRepository.update(EditActor, id, Image);
        //    return View("Actor");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = actorRepository.delete(id);
            return View();
        }
        //Delete Actor
        public IActionResult DeleteActor(int id)
        {
            actorRepository.delete(id);
            return View("Index");
        }
    }
}
