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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = actorRepository.delete(id);
            return View();
        }
    }
}
