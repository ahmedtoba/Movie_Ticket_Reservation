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
        #region Constructor Injection
        public ProducerController(IProducerRepository ProducRepo,IMovieRepository MovRepo, MovieContext _db)
        {
          producerRepository = ProducRepo;
           movieRepository = MovRepo;
            db = _db;

        }
        #endregion
        #region User
        #region Index
        public ActionResult Index()
        {
            List<Producer> Producers = producerRepository.GetAll();
            return View("AllProducers", Producers);
        }
        #endregion
        #region Details
        public ActionResult Details(int id)
        {

            Producer producer = producerRepository.GetById(id);
            return View("DetailsUser", producer);
        }
        #endregion
        #endregion

        #region Admin
        #region Index
        [Authorize(Roles = "Admin")]
        public IActionResult AdminProducers()
        {
            List<Producer> producers = producerRepository.GetAll();
            return View("AdminProducers", producers);
        }
        #endregion
        #region Details
        [Authorize(Roles = "Admin")]
        public ActionResult ProducersDetailsAdmin(int id)
        {

            Producer Actors = producerRepository.GetById(id);
            return View("ProducersDetailsAdmin", Actors);
        }
        #endregion
        #region Insert
        #region Get
        [Authorize(Roles = "Admin")]
        public IActionResult InsertProducerForm()
        {
            return View("InsertProducer", new Producer());
        }


        #endregion
        #region Post
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
        #endregion

        #endregion
        #region Update
        #region Get
        public IActionResult UpdateProducerForm(int id)
        {
            var producer = producerRepository.GetById(id);
            return View("UpdateProducer", producer);
        }
        #endregion
        #region post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Producer EditProducer, int id, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                Task<int> numOfRowsUpdated = producerRepository.update(EditProducer, id, Image);
                return RedirectToAction("AdminProducers");
            }
            return RedirectToAction("Producer");

        }
        #endregion
        #endregion
        #region Delete
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            producerRepository.delete(id);
            return RedirectToAction("adminproducers");
        }
        #endregion
        #endregion
        #region Search
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
        #endregion

        #region GetProducerById
        public IActionResult Producer(int id)
        {
            Producer Producer = producerRepository.GetById(id);
            return View(Producer);
        }
        #endregion

        #region GetProducerByName
        public ActionResult ProducerName(string name)
        {

            Producer Prouducer = producerRepository.GetByName(name);
            return View(Prouducer);
        }
        #endregion





        //insert Producer

        //-------------------------------------------------------------------
        //public IActionResult InsertProducer(Producer InsertProducer, IFormFile Image)
        //{
        //    producerRepository.insert(InsertProducer, Image);
        //    return View("Producer");
        //}

        //Update producer

        //-------------------------------------------------------------
        //public IActionResult UpdateProducer(Producer EditProducer, int id, IFormFile Image)
        //{
        //    producerRepository.update(EditProducer, id, Image);
        //    return View("Producer");
        //}



    }
}
