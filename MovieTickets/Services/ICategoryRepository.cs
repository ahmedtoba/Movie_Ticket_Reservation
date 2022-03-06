using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface ICategoryRepository
    {

        int delete(int id);
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        Task<int> insert(Category newCinema,IFormFile Image);
        int update(Category editMovie, int id, IFormFile Image);
        

    }
}
