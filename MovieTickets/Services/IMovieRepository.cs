using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IMovieRepository
    {

        int delete(int id);
        List<Movie> GetAll();
        Movie GetById(int id);
        Movie GetByName(string name);
        int insert(Movie newCinema);
        int update(Movie editMovie, int id);


    }
}
