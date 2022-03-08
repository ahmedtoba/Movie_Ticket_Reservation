using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public interface ICinemaRepository
    {
        int delete(int id);
        List<Cinema> GetAll();
        Cinema GetById(int id);
        Cinema GetByLocation(string location);
        Cinema GetByName(string name);
       Task<int> insert(Cinema newCinema, List<IFormFile> Image);
        Task<int> update(Cinema EditCin, int id, List<IFormFile> Image);
    }
}