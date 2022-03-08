using Microsoft.AspNetCore.Http;
using MovieTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieTickets.Services
{
    public interface IUpdateProfileRepository
    {
        User GetById(string id);
        Task<int> insert(User NewUser, List<IFormFile> Image);
        int update(string id, User UpdateUser);
    }
}