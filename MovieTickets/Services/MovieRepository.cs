using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> Insert(MovieViewModel movievm,List<IFormFile> Image)
        {
        foreach (var item in Image)
        {
            if (item.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await item.CopyToAsync(stream);
                    movievm.Image = stream.ToArray();
                }
            }
        }
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
                Image=movievm.Image

            });
            //Adding to actor movies table
            foreach (var id in movievm.ActorIds)
            {
                db.MovieActors.Add(new MovieActor()
                {
                    MovieId = newGuid,
                    ActorId = id
                });
            }
            //adding to cinema movies table
            foreach (var id in movievm.CinemaIds)
            {
                db.MovieInCinemas.Add(new MovieInCinema()
                {
                    MovieId = newGuid,
                    CinemaId = id
                });
            }

            return db.SaveChanges();

        }
        public async Task<int> update(MovieViewModel editMovie, Guid Mid,List<IFormFile> Image)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == Mid);
        foreach (var item in Image)
        {
            if (item.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await item.CopyToAsync(stream);
                    editMovie.Image = stream.ToArray();
                }
            }
        }
        movie.Name = editMovie.Name;
            movie.Id = Mid;
            movie.Description = editMovie.Description;
            movie.StartDate = editMovie.StartDate;
            movie.EndDate = editMovie.EndDate;
            movie.Price = editMovie.Price;
              movie.Image = editMovie.Image;
            movie.Rate = editMovie.Rate;
            movie.Cat_Id = editMovie.Category_Id;
            movie.Producer_Id = editMovie.Producer_Id;


            foreach (var id in editMovie.ActorIds)
            {
                db.MovieActors.Update(new MovieActor()
                {
                    MovieId = Mid,
                    ActorId = id
                });
            }
            //adding to cinema movies table
            foreach (var id in editMovie.CinemaIds)
            {
                db.MovieInCinemas.Add(new MovieInCinema()
                {
                    MovieId = Mid,
                    CinemaId = id
                });
            }
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



