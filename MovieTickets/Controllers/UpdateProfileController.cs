using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
using System;
using System.Collections.Generic;

namespace MovieTickets.Controllers
{
    public class UpdateProfileController : Controller
    {
        IUpdateProfileRepository UpProfRepo;

        public UpdateProfileController(IUpdateProfileRepository _UpProfRepo)
        {
            UpProfRepo = _UpProfRepo;
            
        }
       
        public IActionResult UpdateAdminForm()
        {
            string id = HttpContext.Session.GetString("id");
            var user = UpProfRepo.GetById(id);
            return View(user);
        }
        public IActionResult Update(User UpdateUser, List<IFormFile> Image)
        {
            string id = HttpContext.Session.GetString("id");
            if (ModelState.IsValid)
            {
                UpProfRepo.update(id, UpdateUser, Image);
                return RedirectToAction("GetMoviesAdmin", "Movie");
            }
            return View("UpdateAdminForm", UpdateUser);
        }
        public IActionResult UpdateUserForm(string id = "de815c71-7175-4ef8-a28e-3e6b7a1e08b2")
        {
            var user = UpProfRepo.GetById(id);
            return View(user);
        }
        public IActionResult UpdateUser(User UpdateUser, List<IFormFile>Image, string id = "de815c71-7175-4ef8-a28e-3e6b7a1e08b2")
        {
            if (ModelState.IsValid)
            {
                var user = UpProfRepo.update(id,UpdateUser, Image);
                return RedirectToAction("Index", "Home");
            }
            return View("UpdateUserForm", UpdateUser);
        }
    }
    
}
