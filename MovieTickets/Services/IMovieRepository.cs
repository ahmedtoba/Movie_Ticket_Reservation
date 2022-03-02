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
        List<MovieMovieViewModel> GetAll();
        MovieMovieViewModel GetById(Guid id);
        MovieMovieViewModel GetByName(string name);
        Task<int> Insert(MovieViewModel newCinema, List<IFormFile> Image);
        Task<int> update(MovieViewModel editMovie, Guid id, List<IFormFile> Image);


    }
}
