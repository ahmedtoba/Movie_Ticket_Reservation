using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] Image { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public double Rate { get; set; }
        [ForeignKey("Category")]
        public int Cat_Id { get; set; }
        [ForeignKey("Producer")]
        public int Producer_Id { get; set; }
        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual List<MovieOrder> MovieOrders { get; set; }
        public virtual List<MovieInCinema> MoviesInCinema { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }


    }
}
