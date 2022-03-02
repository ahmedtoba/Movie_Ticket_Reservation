using MovieTickets.Models;
using System;
using System.Collections.Generic;

namespace MovieTickets.Services
{
    public interface IActorRepository
    {
       
        int delete(int id);
        List<Actor> GetAll();
        Actor GetById(int id);
        Actor GetByName(string name);
        int insert(Actor newActor);
        int update(Actor EditActor, int id);
    }
}