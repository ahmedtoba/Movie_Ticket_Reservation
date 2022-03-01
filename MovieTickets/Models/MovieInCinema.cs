using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class MovieInCinema
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
