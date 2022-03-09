using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public class UpdateProfileRepository : IUpdateProfileRepository
    {
        MovieContext db;
        public UpdateProfileRepository(MovieContext _db)
        {
            db = _db;
        }
        public User GetById(string id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        //Update user profile -----------------------
        public async Task<int> updateAsync(string id, User UpdateUser,List<IFormFile> Image)
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
            var user = db.Users.SingleOrDefault(u => u.Id == id);
           
            user.FullName = UpdateUser.FullName;
            if (Image.Count != 0)
            {
                user.Image = UpdateUser.Image;
            }
            user.Adress = UpdateUser.Adress;
            int raws = db.SaveChanges();
            return raws;

        }
        //Add new user ---------------------------------------------------
        public async Task<int> insert(User NewUser, List<IFormFile> Image)
        {
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        NewUser.Image = stream.ToArray();
                    }
                }
            }
            db.Add(NewUser);
            return db.SaveChanges();
        }

    }
}
