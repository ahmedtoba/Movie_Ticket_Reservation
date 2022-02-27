using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
       
        public string Bio { get; set; }

       public virtual List<MovieActor> MovieActors { get; set; }
    }
}
