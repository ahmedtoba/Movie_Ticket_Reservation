using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public virtual List<MovieInCinema> MoviesInCinema { get; set; }
    }
}
