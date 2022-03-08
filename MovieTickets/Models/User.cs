using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class User:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string Adress { get; set; }
        public byte[] Image { get; set; }

        public virtual List<MovieOrder> MovieOrders { get; set; }
        public virtual List<Cart> Carts { get; set; }


    }
}
