using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using MovieTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Controllers
{

    public class CartController : Controller
    {
        private readonly ICartRepository cartService;

        public CartController(ICartRepository cartService)
        {
            this.cartService = cartService;
        }
        public IActionResult Index(Cart cart)
        {
           
            cart.UserId = "2a1864ba-567e-4ddd-84af-0466ca59466c";
            
           List<Cart> carts= cartService.GetAll(cart);
            return View(carts);
        }
        public JsonResult Insert(Movie product)
        {

            Cart cart = new Cart()
            {
                UserId = "2a1864ba-567e-4ddd-84af-0466ca59466c",
                MovieId = product.Id,
            };
            var c = cartService.GetAll(cart).ToList();
            if (c.Count == 0)
            {
                cartService.Insert(cart);
            }
            else
            {
                cartService.Delete(cart);
            }
           
            return Json(true);
        }


    }
}
