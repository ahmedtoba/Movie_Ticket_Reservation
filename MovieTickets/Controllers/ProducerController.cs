using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;

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
        public ActionResult Index()
        {
            List<Producer> Producers = producerRepository.GetAll();
            return View();
        }

       
        public ActionResult Details(int id)
        {

            Producer producer = producerRepository.GetById(id);
            return View();
        }


        
        public ActionResult Details(string name)
        {

           Producer Prouducer = producerRepository.GetByName(name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer NewProducer)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsInsertion = producerRepository.insert(NewProducer);
                return View();
            }

            return RedirectToAction();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producer EditProducer, int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsUpdated = producerRepository.update(EditProducer, id);
                return View();
            }
            return RedirectToAction();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = producerRepository.delete(id);
            return View();
        }
    }
}
