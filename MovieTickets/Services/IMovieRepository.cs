using MovieTickets.Models;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IMovieRepository
    {

        int delete(Guid id);
        List<Movie> GetAll();
        Movie GetById(Guid id);
        Movie GetByName(string name);
        int Insert(MovieViewModel newCinema);
        int update(MovieViewModel movievm, Guid id);


    }
}
