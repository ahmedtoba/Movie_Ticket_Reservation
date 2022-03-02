using MovieTickets.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class CategoryRepository :ICategoryRepository
    {
        MovieContext db;
        public CategoryRepository(MovieContext _db)
        {
            db = _db;
        }
        public List<Category> GetAll()
        {
            var category = db.Categories.ToList();
            return category;
        }
        public Category GetById(int id)
        {
            return db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category GetByName(string name)
        {
            return db.Categories.SingleOrDefault(c => c.Name == name);
        }

        public int insert(Category newCategory)
        {
            db.Categories.Add(newCategory);
            int raws = db.SaveChanges();
            return raws;
        }
        public int update(Category editCategory, int id)
        {
            var category = db.Categories.SingleOrDefault(c => c.Id == id);
           category.Id=editCategory.Id;
            category.Name=editCategory.Name;
            category.Movies = editCategory.Movies;


            int raws = db.SaveChanges();
            return raws;
        }
        public int delete(int id)
        {
            Category delCategory = db.Categories.SingleOrDefault(c => c.Id == id);
            db.Categories.Remove(delCategory);
            int raws = db.SaveChanges();
            return raws;
        }
      
    }
}
