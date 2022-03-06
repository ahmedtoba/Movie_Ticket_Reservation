using MovieTickets.Models;
using MovieTickets.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class CartRepository : ICartRepository
    {
        MovieContext db;
        public CartRepository(MovieContext db)
        {
            this.db = db;
        }
        public void Delete(int id)
        {
            var movie = db.Cart.SingleOrDefault(w => w.Id == id);
            db.Cart.Remove(movie);
        }

        public List<Cart> GetAll(Cart carts)
        {
            var cart = db.Cart.Where(w=>w.UserId== carts.UserId).ToList();
            return cart;
        }

        

        public void Insert(Cart cart)
        {
          
           
                db.Cart.Add(cart);
            db.SaveChanges();
        }
    }
}
