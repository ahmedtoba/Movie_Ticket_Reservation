using MovieTickets.Models;
using MovieTickets.ViewModels;

namespace MovieTickets.Services
{
    public interface IMovieOrderRepository
    {

        public void insert(MovieOrder order);
    }
}
