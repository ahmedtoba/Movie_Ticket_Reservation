using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieTickets.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using payment.PaymentData;
using Stripe;

namespace MovieTickets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //payment
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddDbContext<MovieContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("ConnectDb")));


            //Added Services_____________________________
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IMovieInCinemaRepository, MovieInCinemaRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IMovieOrderRepository, MovieOrderRepository>();
            services.AddScoped<IUpdateProfileRepository, UpdateProfileRepository>();

            //___________________________________________
            //Authentication and Authorization

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MovieContext>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "sk_test_51KaLSED25I1FdsuBSpVWATesW9D7o66fKczZ0kPHu1VcwK3NE5BlNwV97iXE2cytRCBxX1bxsyXQwdyNnhmN61bM00AJCInQSA";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //Database Data Initializer
            DBInitializer.SeedDB(app).Wait();
            DBInitializer.CreateUsersAndRolesAsync(app).Wait();
        }
    }
}
