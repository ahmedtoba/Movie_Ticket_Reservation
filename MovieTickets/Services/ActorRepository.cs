using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int insert(Actor newActor)
        {
            db.Actors.Add(newActor);
            int raws = db.SaveChanges();
            return raws;
        }
        public int update(Actor EditActor, int id)
        {
            var Actor = db.Actors.SingleOrDefault(n => n.Id == id);
            Actor.Id = EditActor.Id;
            Actor.Name = EditActor.Name;

            Actor.Image = EditActor.Image;
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
