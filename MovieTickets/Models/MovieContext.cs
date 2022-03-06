using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieTickets.Models
{
    public class MovieContext:IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<MovieInCinema> MovieInCinemas { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<MovieOrder> MovieOrders { get; set; }
        
        public MovieContext() { }
        public MovieContext(DbContextOptions options) : base(options)
        { 
        
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
