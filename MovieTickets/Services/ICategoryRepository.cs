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
        int insert(Category newCinema);
        int update(Category editMovie, int id);

    }
}
