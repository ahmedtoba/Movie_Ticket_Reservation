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
        public ActionResult Index()
        {
            List<Producer> Producers = producerRepository.GetAll();
            return View(Producers);
        }

       
        public ActionResult Details(int id)
        {

            Producer producer = producerRepository.GetById(id);
            return View("DetailsUser",producer);
        }


        
        public ActionResult Details(string name)
        {

           Producer Prouducer = producerRepository.GetByName(name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
          
                return View("InserProducer");
            }

           
         public ActionResult SaveCreate(Producer NewProducer, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsInsertion = producerRepository.insert(NewProducer,Image);
                return View();
            }

            return RedirectToAction();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producer EditProducer, int id,List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
               Task< int> numOfRowsUpdated = producerRepository.update(EditProducer, id,Image);
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
