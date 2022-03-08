using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using Stripe;
using System;

namespace MovieTickets.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
       static MovieOrder orders;


        decimal mony;
        private readonly IMovieOrderRepository movieorderService;
        private readonly IMovieRepository movieservice;

        public PaymentController(IMovieOrderRepository movieorderService,IMovieRepository movieservice)
        {
            this.movieorderService = movieorderService;
            this.movieservice = movieservice;
        }
       

        public IActionResult Index(Movie movie)
        {
            
          orders  = new MovieOrder();
            orders.UserId = HttpContext.Session.GetString("id");
            orders.Movie = movieservice.GetById(movie.Id); 


            return View(orders);
        }



        [HttpPost]
        public IActionResult Processing(MovieOrder order,string stripeToken, string stripeEmail)
        {
          MovieOrder o=new MovieOrder()
          {
              MovieId =order.Movie.Id,
              UserId=order.UserId,
              Quantity =order.Quantity,

          };

            mony = (decimal)(order.Quantity * orders.Movie.Price);

            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "04-234567",
                

            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                /*Amount = HttpContext.Session.GetLong("Amount")*/
                Amount = Convert.ToInt64(mony),
                Currency = "USD",
                Description = "Buying Flowers",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,

            };
            var service = new ChargeService();
            Charge charge = service.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                movieorderService.insert(o);   
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount)  ;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                return RedirectToAction("Index","Cart");
            }

            return View();
        }



    }
}
