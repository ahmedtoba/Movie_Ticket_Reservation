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
        public ActionResult Category(int id)
        {

            Category category = categoryRepo.GetById(id);
            return View(category);
        }
        //public ActionResult Details(int id)
        //{

        //    Category category = categoryRepo.GetById(id);
        //    return View();
        //}


        //get all Categories for admin
        public IActionResult AdminCategories()
        {
            List<Category> categories = categoryRepo.GetAll();
            return View("AdminCategories", categories);
        }
       


        //To get Category by name
        public ActionResult Details(string name)
        {

            Category category = categoryRepo.GetByName(name);
            return View("DetailsUser");
        }
        //The details of Categories for admin
        public ActionResult CategoriesDetailsAdmin(int id)
        {

           Category Categories = categoryRepo.GetById(id);
            return View("CategoriesDetailsAdmin", Categories);
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
        //insert Category
        public IActionResult InsertCategoryForm()
        {
            return View("InsertCategoryForm");
        }
        //--------------------------------------------------------------------------
        public IActionResult InsertActor(Category InsertCategory, IFormFile Image)
        {
            categoryRepo.insert(InsertCategory, Image);
            return View("Category");
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
        public IActionResult UpdateCategoryForm()
        {
            return View("UpdateCategoryForm");
        }
       // ------------------------------------------------------------
        public IActionResult UpdateCategory(Category EditCategory, int id, IFormFile Image)
        {
            categoryRepo.update(EditCategory, id, Image);
            return View("Category");
        }

        // POST: MovieController/Edit/5



        // To delete movies
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = categoryRepo.delete(id);
            return View("Index");
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
