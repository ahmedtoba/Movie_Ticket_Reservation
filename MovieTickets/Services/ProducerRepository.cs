using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTickets.Services
{
    public class ProducerRepository : IProducerRepository
    {
        public Guid id { set; get; }
        public ProducerRepository()
        {
        id=Guid.NewGuid();
        }

        MovieContext db;
        public ProducerRepository(MovieContext _db)
        {
            db = _db;
        }
        public List<Producer> GetAll()
        {
            var producers = db.Producers.ToList();
            return producers;
        }
        public Producer GetById(int id)
        {
            return db.Producers.SingleOrDefault(n => n.Id == id);
        }
        public Producer GetByName(string name)
        {
            return db.Producers.SingleOrDefault(n => n.Name == name);
        }

        //public Producer GetByImage(byte[] image)
        //{
        //    return db.Producers.SingleOrDefault(n => n.Image == image);
        //}
        public int insert(Producer newProducer)
        {
            db.Producers.Add(newProducer);
            int raws = db.SaveChanges();
            return raws;
        }
        public int update(Producer EditProducer, int id)
        {
            var Producer = db.Producers.SingleOrDefault(n => n.Id == id);
            Producer.Id = EditProducer.Id;
            Producer.Name = EditProducer.Name;

            Producer.Image = EditProducer.Image;
            Producer.Bio = EditProducer.Bio;
            int raws = db.SaveChanges();
            return raws;
        }
        public int delete(int id)
        {
            Producer DelPro = db.Producers.SingleOrDefault(n => n.Id == id);
            db.Producers.Remove(DelPro);
            int raws = db.SaveChanges();
            return raws;
        }
    }
}
