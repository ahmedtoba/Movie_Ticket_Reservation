using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;

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


        public ActionResult Index()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View();
        }


        public ActionResult Details(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View();
        }



        public ActionResult Details(string name)
        {

            Actor Actors = actorRepository.GetByName(name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor NewActor)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsInsertion = actorRepository.insert(NewActor);
                return View();
            }

            return RedirectToAction();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor EditActor, int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsUpdated = actorRepository.update(EditActor, id);
                return View();
            }
            return RedirectToAction();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = actorRepository.delete(id);
            return View();
        }
    }
}
