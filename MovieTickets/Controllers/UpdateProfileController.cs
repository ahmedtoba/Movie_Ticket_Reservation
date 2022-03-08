using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Models;
using MovieTickets.Services;
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
       
        public IActionResult UpdateAdminForm(string id= "b0ced795-8acb-4c58-854b-0d344b6c6fa8")
        {
            var user = UpProfRepo.GetById(id);
            return View(user);
        }
        public IActionResult Update(User UpdateUser, List<IFormFile> Image,string id = "b0ced795-8acb-4c58-854b-0d344b6c6fa8")
        {
            if (ModelState.IsValid)
            {
                UpProfRepo.update(id, UpdateUser, Image);
                return RedirectToAction("GetMoviesAdmin", "Movie");
            }
            return View("UpdateAdminForm", UpdateUser);
        }
    }
}
