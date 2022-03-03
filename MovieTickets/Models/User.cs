using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string Adress { get; set; }
        public byte[] Image { get; set; }

        public virtual List<MovieOrder> MovieOrders { get; set; }

       
        
    }
}
