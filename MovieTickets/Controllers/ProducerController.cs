using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class ProducerController : Controller
    {

         IProducerRepository producerRepository;
        IMovieRepository movieRepository;

        public ProducerController(IProducerRepository ProducRepo,IMovieRepository MovRepo)
        {
          producerRepository = ProducRepo;
           movieRepository = MovRepo;

        }
        //get all Producers for users 
        public ActionResult Index()
        {
            List<Producer> Producers = producerRepository.GetAll();
            return View("AllProducers", Producers);
        }
        //get all producers for admin
        public IActionResult AdminProducers()
        {
            List<Producer> producers = producerRepository.GetAll();
            return View("AdminProducers", producers);
        }




        public ActionResult Details(int id)
        {

            Producer producer = producerRepository.GetById(id);
            return View("DetailsUser",producer);
        }
        //The details of actors for admin
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
        public IActionResult InsertProducerForm()
        {
            return View("InsertProducerForm");
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer NewProducer, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsInsertion = producerRepository.insert(NewProducer, Image);
                return View();
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
        public ActionResult Edit(Producer EditProducer, int id,List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task< int> numOfRowsUpdated = producerRepository.update(EditProducer, id,Image);
                return View();
            }
            return RedirectToAction("Producer");

        }
        //Update producer
        public IActionResult UpdateProducerForm()
        {
            return View("UpdateProducerForm");
        }
        //-------------------------------------------------------------
        //public IActionResult UpdateProducer(Producer EditProducer, int id, IFormFile Image)
        //{
        //    producerRepository.update(EditProducer, id, Image);
        //    return View("Producer");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = producerRepository.delete(id);
            return View();
        }
        public IActionResult DeleteProducer(int id)
        {
            producerRepository.delete(id);
            return View("Index");
        }
    }
}
