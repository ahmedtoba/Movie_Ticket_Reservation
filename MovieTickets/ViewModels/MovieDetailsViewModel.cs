using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public List<MovieInCinema> MoviesInCinemas { get; set; }

    }
}
