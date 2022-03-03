using MovieTickets.Models;
using System;
using System.Collections.Generic;

namespace MovieTickets.ViewModels
{
    public class MovieItemViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Category> Categories { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public Guid MovieId { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        public Guid ActorId { get; set; }
    }
}
