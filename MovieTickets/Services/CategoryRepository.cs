﻿using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> insert(Category newCategory,IFormFile Image)
        {
            
                if (Image.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        newCategory.Image = stream.ToArray();
                    }
                
            }
            db.Categories.Add(newCategory);
            int raws = db.SaveChanges();
            return raws;
        }
        public async Task<int> update(Category editCategory, int id,IFormFile Image)
        {
            var category = db.Categories.SingleOrDefault(c => c.Id == id);
            
                if (Image.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        editCategory.Image = stream.ToArray();
                    }
                }
            
           
            category.Name=editCategory.Name;
           category.Image=editCategory.Image;
            category.Description=editCategory.Description;




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
