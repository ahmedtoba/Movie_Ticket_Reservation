using MovieTickets.Models;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IMovieRepository
    {

        int delete(Guid id);
        List<MovieMovieViewModel> GetAll();
        MovieMovieViewModel GetById(Guid id);
        MovieMovieViewModel GetByName(string name);
        int Insert(MovieViewModel newCinema);
        int update(MovieViewModel editMovie, Guid id);


    }
}
