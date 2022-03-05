using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public interface IMovieRepository
    {

        int delete(Guid id);
        List<Movie> GetAll();
        MovieViewModel GetMovieByIdAdmin(Guid id);
        Movie GetById(Guid id);
        Movie GetByName(string name);
        Task<int> Insert(MovieViewModel newCinema, List<IFormFile> Image);
        Task<int> update(MovieViewModel editMovie, Guid id, List<IFormFile> Image);


    }
}
