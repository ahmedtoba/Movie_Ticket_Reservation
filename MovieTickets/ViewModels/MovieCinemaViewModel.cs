using MovieTickets.Models;
using System.Collections.Generic;

namespace MovieTickets.ViewModels
{
    public class MovieCinemaViewModel
    {
        public virtual Cinema Cinema { get; set; }
        public virtual List<MovieInCinema> Movies { get; set; }
    }
}
