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
    public class ProducerController : Controller
    {

         IProducerRepository producerRepository;
        IMovieRepository movieRepository;
        MovieContext db;

        public ProducerController(IProducerRepository ProducRepo,IMovieRepository MovRepo, MovieContext _db)
        {
          producerRepository = ProducRepo;
           movieRepository = MovRepo;
            db = _db;

        }
        //get all Producers for users 
        public ActionResult Index()
        {
            List<Producer> Producers = producerRepository.GetAll();
            return View("AllProducers", Producers);
        }
        //get all producers for admin
        [Authorize(Roles = "Admin")]
        public IActionResult AdminProducers()
        {
            List<Producer> producers = producerRepository.GetAll();
            return View("AdminProducers", producers);
        }

        //searching----------------------------------------------
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminProducers(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var producers = db.Producers.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                producers = producers.Where(c => c.Name.Contains(Keyword));

            }
            return View(await producers.AsNoTracking().ToListAsync());
        }


        public ActionResult Details(int id)
        {

            Producer producer = producerRepository.GetById(id);
            return View("DetailsUser",producer);
        }
        //The details of actors for admin
        [Authorize(Roles = "Admin")]
        public ActionResult ProducersDetailsAdmin(int id)
        {

            Producer Actors = producerRepository.GetById(id);
            return View("ProducersDetailsAdmin", Actors);
        }

        //Details of producers for users---------------------------------- 
        public IActionResult Producer(int id)
        {
           Producer Producer = producerRepository.GetById(id);
            return View(Producer);
        }


        //searching----------------------------------------------
        public ActionResult ProducerName(string name)
        {

            Producer Prouducer = producerRepository.GetByName(name);
            return View(Prouducer);
        }


        //insert Producer
        [Authorize(Roles = "Admin")]
        public IActionResult InsertProducerForm()
        {
            return View("InsertProducer", new Producer());
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Producer NewProducer, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsInsertion = producerRepository.insert(NewProducer, Image);
                return RedirectToAction("AdminProducers");
            }

            return RedirectToAction("Producer");
        }
        //-------------------------------------------------------------------
        //public IActionResult InsertProducer(Producer InsertProducer, IFormFile Image)
        //{
        //    producerRepository.insert(InsertProducer, Image);
        //    return View("Producer");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Producer EditProducer, int id,List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task< int> numOfRowsUpdated = producerRepository.update(EditProducer, id,Image);
                return RedirectToAction("AdminProducers");
            }
            return RedirectToAction("Producer");

        }
        //Update producer
        public IActionResult UpdateProducerForm(int id)
        {
            var producer = producerRepository.GetById(id);
            return View("UpdateProducer", producer);
        }
        //-------------------------------------------------------------
        //public IActionResult UpdateProducer(Producer EditProducer, int id, IFormFile Image)
        //{
        //    producerRepository.update(EditProducer, id, Image);
        //    return View("Producer");
        //}


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            producerRepository.delete(id);
            return RedirectToAction("adminproducers");
        }
    }
}
