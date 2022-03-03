using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<User> roleManager;
        private readonly MovieContext db;

        public AccountController(UserManager<User> userManager, RoleManager<User> roleManager, MovieContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.db = db;
        }

        
    }
}
