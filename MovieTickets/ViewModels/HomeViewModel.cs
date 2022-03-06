using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.ViewModels
{
    public class HomeViewModel
    {
        public virtual List<Cinema> Cinemas { get; set; }
        public virtual List<Movie> Movies { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Actor> Actors { get; set; }
    }
}
