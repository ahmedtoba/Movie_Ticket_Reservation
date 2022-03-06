using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;

namespace MovieTickets.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {

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
                Amount = Convert.ToInt64(555.44),
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
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                return View("succeeded");
            }

            return View();
        }



    }
}
