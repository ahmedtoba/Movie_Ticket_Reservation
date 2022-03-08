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
        MovieContext db;
        #region Constructor Injection
        public ActorController(IActorRepository ActRepo, MovieContext _db)
        {
            actorRepository= ActRepo;
            db= _db;

        }
        #endregion
        //get all actors for users 
        #region User
        #region User Index
        public ActionResult Index()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View(Actors);
        }
        #endregion
        #region User Details
        public ActionResult Details(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View("DetailsUser", Actors);
        }
        #endregion
        #endregion

        #region Admin
        #region  Index
        [Authorize(Roles = "Admin")]
        public IActionResult AdminActors()
        {
            List<Actor> Actors = actorRepository.GetAll();
            return View("AdminActors", Actors);
        }
        #endregion
        #region  Details
        [Authorize(Roles = "Admin")]
        public ActionResult ActorsDetailsAdmin(int id)
        {

            Actor Actors = actorRepository.GetById(id);
            return View("ActorsDetailsAdmin", Actors);
        }
        #endregion
        #region Insert
        #region Get
        public IActionResult InsertActorForm()
        {
            return View("InsertActor", new Actor());
        }
        #endregion
        #region post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Actor NewActor, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsInsertion = actorRepository.insert(NewActor, Image);
                return RedirectToAction("AdminActors");
            }

            return RedirectToAction("Actor");
        }
        #endregion

        #endregion
        #region Update
        #region Get
        public IActionResult UpdateActorForm(int id)
        {
            var actor = actorRepository.GetById(id);

            return View("UpdateActor", actor);
        }
        #endregion
        #region post
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
        #endregion
        #endregion
        #region Delete
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            actorRepository.delete(id);
            return RedirectToAction("AdminActors");
        }
        #endregion
        #endregion


        #region Search


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
       

        #endregion


        #region GetByName
        public ActionResult ActorName(string name)
        {

            Actor Actors = actorRepository.GetByName(name);
            return View(Actors);
        }
        #endregion



        //The details of actors for admin
       

       

        //Details of actors for users---------------------------------- 
        //public IActionResult Actor(int id)
        //{
        //    Actor Actor = actorRepository.GetById(id);
        //    return View(Actor);
        //}
        //Searching-------------------------------------
     


        //insert actor
       
        //--------------------------------------------------------------------------
        //public IActionResult InsertActor(Actor InsertActor, IFormFile Image)
        //{
        //    actorRepository.insert(InsertActor, Image);
        //    return View("Actor");
        //}
       
      
        //Update actor

        //------------------------------------------------------------
        //public IActionResult UpdateActor(Actor EditActor, int id, IFormFile Image)
        //{
        //    actorRepository.update(EditActor, id, Image);
        //    return View("Actor");
        //}



        //Delete Actor
      
    }
}
