using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.ViewModels;
using System;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly MovieContext db;
        #region Constructor Injection
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, MovieContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.db = db;
        }
        #endregion
        #region LogIn
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                
                var user = await userManager.FindByNameAsync(loginVM.UserLogin);
                user = (user != null) ? user : await userManager.FindByEmailAsync(loginVM.UserLogin);
                if (user != null)
                {
                    var passwordCheck = await userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                        if (result.Succeeded)
                        {
                            HttpContext.Session.SetString("id", user.Id);
                            

                            var checkIfAdmin = await userManager.GetRolesAsync(user);
                            if (checkIfAdmin.Contains("Admin"))
                               
                            return RedirectToAction("Admin", "Home");
                            
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            TempData["Error"] = "Wrong Login. Please, try again!";
            return View(loginVM);
        }


        #endregion 

        #region SignUp
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpVM)
        {
            if (ModelState.IsValid)
            {
                var userByEmail = await userManager.FindByEmailAsync(signUpVM.Email);
                var userByUserName = await userManager.FindByNameAsync(signUpVM.UserName);

                if (userByEmail == null && userByUserName == null)
                {
                    var newUser = new User()
                    {
                        UserName = signUpVM.UserName,
                        Email = signUpVM.Email,
                        FullName = signUpVM.FullName,
                    };
                    var response = await userManager.CreateAsync(newUser, signUpVM.Password);
                    if (response.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, UserRoles.User);
                    }

                    return RedirectToAction("SignUpCompleted");
                }
                if (userByUserName != null)
                    TempData["Error"] = "UserName Already Exists";
                if (userByEmail != null)
                    TempData["Error"] = "Email Already Exists";
                return View(signUpVM);
            }
            TempData["Error"] = "Login Error, Please Try again, Ensure to enclue complex password";
            return View(signUpVM);
        }
        
        public IActionResult SignUpCompleted()
        {
            return View();
        }

        #endregion
        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
