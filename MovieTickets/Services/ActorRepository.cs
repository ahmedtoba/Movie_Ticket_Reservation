using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public class ActorRepository : IActorRepository
    {
       
        
        MovieContext db;
        public ActorRepository(MovieContext _db)
        {
            db = _db;
        }
        public List<Actor> GetAll()
        {
            var Actors = db.Actors.ToList();
            return Actors;
        }
        public Actor GetById(int id)
        {
            return db.Actors.SingleOrDefault(n => n.Id == id);
        }
        public Actor GetByName(string name)
        {
            return db.Actors.SingleOrDefault(n => n.Name == name);
        }

        //public Actor GetByImage(byte[] image)
        //{
        //    return db.Actors.SingleOrDefault(n => n.Image == image);
        //}
        public async Task<int> insert(Actor newActor, List<IFormFile> Image)
        {
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        newActor.Image = stream.ToArray();
                    }
                }
            }
            db.Actors.Add(newActor);
            int raws = db.SaveChanges();
            return raws;
        }
        public async Task<int> update(Actor EditActor, int id, List<IFormFile> Image)
        {
            var Actor = db.Actors.SingleOrDefault(n => n.Id == id);
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        EditActor.Image = stream.ToArray();
                    }
                }
            }
            Actor.Id = EditActor.Id;
            Actor.Name = EditActor.Name;
            if (Image.Count!= 0)
            {
                Actor.Image = EditActor.Image;
            }
            Actor.Bio = EditActor.Bio;
            int raws = db.SaveChanges();
            return raws;
        }
        public int delete(int id)
        {
            Actor DelAct = db.Actors.SingleOrDefault(n => n.Id == id);
            db.Actors.Remove(DelAct);
            int raws = db.SaveChanges();
            return raws;
        }

    }
}
