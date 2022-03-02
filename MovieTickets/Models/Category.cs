using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual  List<MovieMovieViewModel> Movies { get; set; }
    }
}
