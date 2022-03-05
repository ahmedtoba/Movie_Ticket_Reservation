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
            return View("AllActors", Actors);
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



        //public ActionResult Details(string name)
        //{

        //    Actor Actors = actorRepository.GetByName(name);
        //    return View();
        //}
        //insert actor
        public IActionResult InsertActor()
        {
            return View("InsertActor");
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

            return RedirectToAction();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor EditActor, int id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task<int> numOfRowsUpdated = actorRepository.update(EditActor, id, Image);
                return View();
            }
            return RedirectToAction();

        }
        //Update actor
        public IActionResult UpdateActor()
        {
            return View("UpdateActor");
        }

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
