using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface ICinemaRepository
    {
        int delete(int id);
        List<Cinema> GetAll();
        Cinema GetById(int id);
        Cinema GetByLocation(string location);
        Cinema GetByName(string name);
        int insert(Cinema newCinema);
        int update(Cinema EditCin, int id);
    }
}