using MovieTickets.Models;
using System;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IProducerRepository
    {
        Guid id { get; set; }
        int delete(int id);
        List<Producer> GetAll();
        Producer GetById(int id);
        Producer GetByName(string name);
        int insert(Producer newProducer);
        int update(Producer EditProducer, int id);
    }
}