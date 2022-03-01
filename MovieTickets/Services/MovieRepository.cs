using MovieTickets.Models;
using MovieTickets.ViewModels;
using System;
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
        public Movie GetById(Guid id)
        {
            return db.Movies.SingleOrDefault(c => c.Id == id);
        }

        public Movie GetByName(string name)
        {
            return db.Movies.SingleOrDefault(c => c.Name == name);
        }
       
        public int Insert(MovieViewModel movievm)
        {
            //Adding to movie table
            var newGuid = Guid.NewGuid();
            db.Movies.Add(new Movie()
            {
                Name = movievm.Name,
                Id = newGuid,
                StartDate = movievm.StartDate,
                EndDate = movievm.EndDate,
                Price = movievm.Price,
                Description = movievm.Description,
                Cat_Id = movievm.Category_Id,
                Rate = movievm.Rate,
                Producer_Id = movievm.Producer_Id,
            }) ;
            //Adding to actor movies table
            foreach(var id in movievm.ActorIds)
            {
                db.MovieActors.Add(new MovieActor()
                {
                    MovieId = newGuid,
                    ActorId = id
                }) ;
            }
            //adding to cinema movies table
            foreach(var id in movievm.CinemaIds)
            {
                db.MovieInCinemas.Add(new MovieInCinema()
                {
                    MovieId = newGuid,
                    CinemaId = id
                }) ;
            }

            return db.SaveChanges();
            
        }
        public int update(Movie editMovie, Guid id)
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
        public int delete(Guid id)
        {
            Movie delMovie = db.Movies.SingleOrDefault(c => c.Id == id);
            db.Movies.Remove(delMovie);
            int raws = db.SaveChanges();
            return raws;
        }
    }
}