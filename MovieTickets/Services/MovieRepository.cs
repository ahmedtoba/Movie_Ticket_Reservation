using MovieTickets.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class MovieRepository:IMovieRepository
    {
        MovieContext db;
        public MovieRepository(MovieContext _db)
        {
            db = _db;
        }
        public List<Movie> GetAll()
        {
            var movies = db.Movies.ToList();
            return movies;
        }
        public Movie GetById(int id)
        {
            return db.Movies.SingleOrDefault(c => c.Id == id);
        }

        public Movie GetByName(string name)
        {
            return db.Movies.SingleOrDefault(c => c.Name == name);
        }
       
        public int insert(Movie newMovie)
        {
            db.Movies.Add(newMovie);
            int raws = db.SaveChanges();
            return raws;
        }
        public int update(Movie editMovie, int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);
            movie.Name = editMovie.Name;
            movie.Id = editMovie.Id;
            movie.Description = editMovie.Description;
            movie.StartDate= editMovie.StartDate;
            movie.EndDate= editMovie.EndDate;
        
            movie.Image = editMovie.Image;
            movie.Price=editMovie.Price;
            movie.Trailer=editMovie.Trailer;
            movie.Rate=editMovie.Rate;
            movie.Cat_Id=editMovie.Cat_Id;
            movie.Producer_Id = editMovie.Producer_Id;
            movie.Category=editMovie.Category;
            movie.Producer=editMovie.Producer;
            movie.MovieOrders=editMovie.MovieOrders;
            movie.MoviesInCinema=editMovie.MoviesInCinema;
            movie.MovieActors = editMovie.MovieActors;
            int raws = db.SaveChanges();
            return raws;
        }
        public int delete(int id)
        {
            Movie delMovie = db.Movies.SingleOrDefault(c => c.Id == id);
            db.Movies.Remove(delMovie);
            int raws = db.SaveChanges();
            return raws;
        }
    }
}