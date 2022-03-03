using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IMovieActorRepository
    {
        public List<MovieActor> GetAll();
    }
}
