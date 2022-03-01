using MovieTickets.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class MovieInCinemaRepository : IMovieInCinemaRepository
    {
        MovieContext db;
        public MovieInCinemaRepository(MovieContext db)
        {
           this.db = db;
        }

        public List<MovieInCinema> GetAll()
        {
            var Movies = db.MovieInCinemas.ToList();
            return Movies;
        }

        public MovieInCinema GetById(int id)
        {
            var Movie = db.MovieInCinemas.SingleOrDefault(w=>w.Id==id);
            return Movie;
        }

        public void Insert(List<MovieInCinema> mic)
        {
            foreach(var item in mic)
            db.MovieInCinemas.Add(item);
            db.SaveChanges();
        }

        public void Update(int id, MovieInCinema mic)
        {
            var oldMovie = db.MovieInCinemas.SingleOrDefault(w => w.Id == id);
            oldMovie.CinemaId = mic.CinemaId;
            oldMovie.MovieId = mic.MovieId;
            oldMovie.Quantity = mic.Quantity;

        }

        public void Delete(int id)
        {
            var movie = db.MovieInCinemas.SingleOrDefault(w => w.Id == id);
            db.MovieInCinemas.Remove(movie);
        }
    }
}
