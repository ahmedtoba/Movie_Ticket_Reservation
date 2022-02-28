﻿using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public string Bio { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
}
