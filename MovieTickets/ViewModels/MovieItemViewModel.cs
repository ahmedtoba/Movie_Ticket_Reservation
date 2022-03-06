using MovieTickets.Models;
using System;
using System.Collections.Generic;

namespace MovieTickets.ViewModels
{
    public class MovieItemViewModel
    {
        public virtual List<Movie> Movies { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public virtual List<Producer> Producers { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }
        public  Guid MovieId { get; set; }
        public  int CinemaId { get; set; }
        public  int CategoryId { get; set; }
        public  int ProducerId { get; set; }
        public  Guid ActorId { get; set; }
    }
}
