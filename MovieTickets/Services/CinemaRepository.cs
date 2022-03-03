using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public class CinemaRepository : ICinemaRepository
    {
        MovieContext db;
        public CinemaRepository(MovieContext _db)
        {
            db = _db;
        }
        public List<Cinema> GetAll()
        {
            var cinemas = db.Cinemas.ToList();
            return cinemas;
        }
        public Cinema GetById(int id)
        {
            return db.Cinemas.SingleOrDefault(c => c.Id == id);
        }
        public Cinema GetByName(string name)
        {
            return db.Cinemas.SingleOrDefault(c => c.Name == name);
        }
        public Cinema GetByLocation(string location)
        {
            return db.Cinemas.SingleOrDefault(c => c.Location == location);
        }
       
        
        public int delete(int id)
        {
            Cinema delcin = db.Cinemas.SingleOrDefault(c => c.Id == id);
            db.Cinemas.Remove(delcin);
            int raws = db.SaveChanges();
            return raws;
        }

        public async Task<int> insert(Cinema newCinema, IFormFile Image)
        {
            
                if (Image.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        newCinema.Image = stream.ToArray();
                    }
                }
            
            db.Cinemas.Add(newCinema);
            int raws = db.SaveChanges();
            return raws;
        }

        public async Task<int> update(Cinema EditCin, int id, IFormFile Image)
        {
            var cinema = db.Cinemas.SingleOrDefault(c => c.Id == id);
            
                if (Image.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await Image.CopyToAsync(stream);
                        EditCin.Image = stream.ToArray();
                    }
                }
            
            cinema.Name = EditCin.Name;
            cinema.Location = EditCin.Location;
            cinema.Image = EditCin.Image;
            cinema.Location = EditCin.Location;
            int raws = db.SaveChanges();
            return raws;
        }
    }
}
