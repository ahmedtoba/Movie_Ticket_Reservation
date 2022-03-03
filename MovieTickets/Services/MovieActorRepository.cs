using MovieTickets.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class MovieActorRepository : IMovieActorRepository
    {
        MovieContext db;
        public MovieActorRepository(MovieContext db)
        {
           this.db = db;
        }
        public List<MovieActor> GetAll()
        {
            var MovieActor = db.MovieActors.ToList();
            return MovieActor;
        }
    }
}
