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

            return View();
        }

        // To Get Category by ID
        public ActionResult Details(int id)
        {

            Category category = categoryRepo.GetById(id);
            return View();
        }


        //To get Category by name
        public ActionResult Details(string name)
        {

            Category category = categoryRepo.GetByName(name);
            return View();
        }


        // To add new movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsInsertion = categoryRepo.insert(newCategory);
                return View();
            }

            return RedirectToAction();
        }



        // To Edit any Movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category editCategory, int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRowsUpdated = categoryRepo.update(editCategory, id);
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

        // POST: MovieController/Delete/5


    }
}
