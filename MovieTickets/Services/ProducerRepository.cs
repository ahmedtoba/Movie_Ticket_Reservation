using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<int> insert(Producer newProducer,List<IFormFile>Image)
        {
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        newProducer.Image = stream.ToArray();
                    }
                }
            }
            db.Producers.Add(newProducer);
            int raws = db.SaveChanges();
            return raws;
        }
        public async Task<int> update(Producer EditProducer, int id,List<IFormFile> Image)
        {
            var Producer = db.Producers.SingleOrDefault(n => n.Id == id);
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        EditProducer.Image = stream.ToArray();
                    }
                }
            }
            Producer.Id = EditProducer.Id;
            Producer.Name = EditProducer.Name;
            if(Image.Count!=0)
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
