using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using Stripe;
using System;

namespace MovieTickets.Controllers
{
    public class PaymentController : Controller
    {

        decimal mony;
        public IActionResult Index()
        {

           

            return View();
        }



        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            mony = (decimal)(50 * 5);

            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "04-234567"

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
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount)  ;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                return View("succeeded");
            }

            return View();
        }



    }
}
