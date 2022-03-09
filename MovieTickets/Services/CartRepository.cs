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
        public void Delete(Cart cart)
        {
            var movie = db.Cart.Where(w => w.UserId == cart.UserId).SingleOrDefault(w=>w.MovieId==cart.MovieId);
            db.Cart.Remove(movie);
            db.SaveChanges();
        }

        public List<Cart> GetAll(Cart carts)
        {
            var cart = db.Cart.Where(w=>w.UserId== carts.UserId).ToList();
            return cart;
        }

        public List<Cart> GetData(Cart carts)
        {
            var cart = db.Cart.Where(w => w.UserId == carts.UserId).Where(w => w.MovieId == carts.MovieId).ToList();
            return cart;
        }

        public void Insert(Cart cart)
        {
          
           
                db.Cart.Add(cart);
            db.SaveChanges();
        }
    }
}
