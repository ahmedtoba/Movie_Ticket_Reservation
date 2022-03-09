using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MovieTickets.Controllers
{
    public class UpdateProfileController : Controller
    {
        IUpdateProfileRepository UpProfRepo;
        private readonly UserManager<User> userManager;

        public UpdateProfileController(IUpdateProfileRepository _UpProfRepo, UserManager<User> userManager)
        {
            UpProfRepo = _UpProfRepo;
            this.userManager = userManager;
        }
       
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateAdminForm(Guid id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(User UpdateUser, List<IFormFile> Image)
        {
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        UpdateUser.Image = stream.ToArray();
                    }
                }
            }
            string id = HttpContext.Session.GetString("id");
            if (ModelState.IsValid)
            {
              await  UpProfRepo.updateAsync(id, UpdateUser,Image);
                return RedirectToAction("GetMoviesAdmin", "Movie");
            }
            return View("UpdateAdminForm", UpdateUser);
        }

        [Authorize]
        public IActionResult UpdateUserForm(Guid id)
        {
            var user = UpProfRepo.GetById(id.ToString());
            return View(user);
        }
        public async Task<IActionResult> UpdateUserAsync(User UpdateUser,List<IFormFile> Image)
        {
            
            string id=HttpContext.Session.GetString("id");
           
              await  UpProfRepo.updateAsync(id,UpdateUser, Image);
                return RedirectToAction("Index", "Home");
            
            return View("UpdateUserForm", UpdateUser);
        }
    }
    
}
