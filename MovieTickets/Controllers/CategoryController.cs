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
   
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepo;
        MovieContext db;

        public CategoryController(ICategoryRepository _categoryRepo, MovieContext _db)
        {
            this.categoryRepo = _categoryRepo;
            this.db = _db;


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
        //searching ---------------------------
        [HttpGet]
        public async Task<IActionResult> AdminCategories(string Keyword)
        {
            ViewData["searching"] = Keyword;
            var categories = db.Categories.Select(x => x);
            if (!string.IsNullOrEmpty(Keyword))
            {
                categories = categories.Where(c => c.Name.Contains(Keyword));

            }
            return View(await categories.AsNoTracking().ToListAsync());
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
        //insert form ------------------------------------------
        public IActionResult InsertCategoryForm()
        {
            return View("InsertCategoryForm", new Category());
        }
        // To add new movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category newCategory, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.insert(newCategory, Image);
                return RedirectToAction("AdminCategories");
            }
            
            return RedirectToAction("InsertCategoryForm");
            //Retrun to Details
        }
       
        //insert Category
       
        //-------------------------------------------------------------------------



        // To Edit any Movie
       
        public IActionResult UpdateCategoryForm(int id)
        {
            var category = categoryRepo.GetById(id);
            return View("UpdateCategoryForm", category);
        }
       // ------------------------------------------------------------
        public IActionResult UpdateCategory(Category EditCategory, int id, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.update(EditCategory, id, Image);
                return RedirectToAction("AdminCategories");
            }
            return RedirectToAction("UpdateCategoryForm", EditCategory);
        }

        // POST: MovieController/Edit/5



        // To delete movies
        public ActionResult Delete(int id)
        {
            int numOfRowsDeleted = categoryRepo.delete(id);
            return RedirectToAction("AdminCategories");

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
