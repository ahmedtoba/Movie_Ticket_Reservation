using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class MovieActor
    {
        public int Id { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
