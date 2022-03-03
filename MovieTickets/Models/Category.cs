using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
