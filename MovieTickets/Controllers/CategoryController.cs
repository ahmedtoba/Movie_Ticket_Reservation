using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System.Collections.Generic;

namespace MovieTickets.Controllers
{
   
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;


        }



        // To get All categories
        public ActionResult Index()
        {

            List<Category> categories= categoryRepo.GetAll();

            return View(categories);
        }

        // To Get Category by ID
        public ActionResult Details(int id)
        {

            Category category = categoryRepo.GetById(id);
            return View("DetailsUser", category);
        }


        //To get Category by name
        //public ActionResult Details(string name)
        //{

        //    Category category = categoryRepo.GetByName(name);
        //    return View("DetailsUser");
        //}


        // To add new movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newCategory,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.insert(newCategory, Image);
                return View();
            }

            return RedirectToAction();
        }



        // To Edit any Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category editCategory, int id,IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                 categoryRepo.update(editCategory, id, Image);
                return View();
            }
            return RedirectToAction();

        }

        // POST: MovieController/Edit/5



        // To delete movies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = categoryRepo.delete(id);
            return View();
        }

        public ActionResult Grid()
        {
           
            return PartialView("_Grid", categoryRepo.GetAll());
        }

        public ActionResult List()
        {

            return PartialView("_List", categoryRepo.GetAll());
        }
       


    }
}
