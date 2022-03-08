using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTickets.Models
{
    public class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public class DBInitializer
    {
        public static async Task<byte[]> ImageConverter(string imageName)
        {
            string path = "./wwwroot/images/" + imageName;
            var stream = File.OpenRead(path);
            var formfile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            using (var _stream = new MemoryStream())
            {
                await formfile.CopyToAsync(_stream);
                return _stream.ToArray();
            }
        }

        


        public static async Task SeedDB(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<MovieContext>();

                db.Database.EnsureCreated();


                //Seeding Categories
                if (!db.Categories.Any())
                {
                    db.Categories.AddRange(new List<Category>()
                    {
                        new Category() { Name = "Comdey"},
                        new Category() { Name = "Romance"},
                        new Category() { Name = "Drama"},
                        new Category() { Name = "Action"},
                        new Category() { Name = "Thriller"},
                        new Category() { Name = "Horror"},
                        new Category() { Name = "Animation"},
                        new Category() { Name = "Adventure"},
                        new Category() { Name = "Documentary"},
                        new Category() { Name = "Science Fiction"}
                    });
                }

                //Adding Cinemas

                if (!db.Cinemas.Any())
                {
                    db.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema() { Name ="IMax Americana", Location ="Giza", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
                        new Cinema() { Name ="Point 90 Cinema", Location ="Cairo", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
                        new Cinema() { Name ="Vox Cinema", Location ="Cairo", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
                        new Cinema() { Name ="Renaissance Cinema St. Stefano", Location ="Alexandria", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
                    });
                }


                //Adding Actors
                if (!db.Actors.Any())
                {
                    db.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name ="Matt LeBlanc",
                            Image = await ImageConverter("actor-1.jpeg"),
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new Actor()
                        {
                            Name ="Chris Tucker",
                            Image = await ImageConverter("actor-2.jpeg"),
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new Actor()
                        {
                            Name ="Angelina Jolie",
                            Image = await ImageConverter("actor-3.jpeg"),
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new Actor()
                        {
                            Name ="Jim Carrey",
                            Image = await ImageConverter("actor-4.jpeg"),
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new Actor()
                        {
                            Name ="Will Smith",
                            Image = await ImageConverter("actor-5.jpeg"),
                            Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },

                    });
                }

                    if (!db.Producers.Any())
                    {
                        db.Producers.AddRange(new List<Producer>() 
                        {
                            new Producer()
                            {
                                Name = "Kevin Feige",
                                Image = await ImageConverter("producer_1.jpg"),
                                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                            },
                            new Producer()
                            {
                                Name = "Quantin Tarantino",
                                Image = await ImageConverter("producer_2.jpg"),
                                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                            },
                        });
                    }
                db.SaveChanges();


                    //Adding Movies Here

                    if (!db.Movies.Any())
                    {
                    //start of adding movie
                        Guid guid1 = Guid.NewGuid();
                        var movie1 = new Movie()
                        {
                            Id = guid1,
                            Name = "Django Unchained",
                            StartDate = new DateTime(2022, 1, 30),
                            EndDate = new DateTime(2022, 6, 14),
                            Rate = 8,
                            Trailer= "https://www.youtube.com/watch?v=eUdM9vrCbow",
                            Price = 120,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            Producer_Id = 2,
                            Cat_Id = 6,
                            Image = await ImageConverter("movie-1.jpg"),
                        };
                        db.Movies.Add(movie1);
                    var actors1 = new List<int> { 1, 3, 5 };
                        foreach (var id in actors1)
                        {
                            db.MovieActors.Add(new MovieActor()
                            {
                                MovieId = guid1,
                                ActorId = id
                            });
                        }
                    var cinemas1 = new List<int> { 1, 3, 4 };
                    var quantities1 = new List<int> { 50, 40, 30 };

                        //adding to cinema movies table
                        for (var i = 0; i < cinemas1.Count; i++)
                        {
                            db.MovieInCinemas.Add(new MovieInCinema()
                            {
                                Quantity = quantities1[i],
                                MovieId = guid1,
                                CinemaId = cinemas1[i]
                            });
                        }
                        //end of adding one movie
                        
                        //start of adding movie
                        Guid guid2 = Guid.NewGuid();
                        var movie2 = new Movie()
                        {
                            Id = guid2,
                            Name = "Tyson's Run (2022)",
                            StartDate = new DateTime(2022, 3, 30),
                            EndDate = new DateTime(2022, 8, 14),
                            Rate = 7,
                            Trailer= "https://www.youtube.com/watch?v=hEqSj5esw7k",
                            Price = 150,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            Producer_Id = 1,
                            Cat_Id = 5,
                            Image = await ImageConverter("movie-2.jpg"),
                        };
                        db.Movies.Add(movie2);
                    var actors2 = new List<int> { 2, 4, 5 };
                        foreach (var id in actors2)
                        {
                            db.MovieActors.Add(new MovieActor()
                            {
                                MovieId = guid2,
                                ActorId = id
                            });
                        }
                    var cinemas2 = new List<int> { 2, 4 };
                    var quantities2 = new List<int> { 40, 60 };

                        //adding to cinema movies table
                        for (var i = 0; i < cinemas2.Count; i++)
                        {
                            db.MovieInCinemas.Add(new MovieInCinema()
                            {
                                Quantity = quantities2[i],
                                MovieId = guid2,
                                CinemaId = cinemas2[i]
                            });
                        }
                    //end of adding one movie

                    //start of adding movie
                    Guid guid3 = Guid.NewGuid();
                    var movie3 = new Movie()
                    {
                        Id = guid3,
                        Name = "Offseason (2021)",
                        StartDate = new DateTime(2021, 3, 30),
                        EndDate = new DateTime(2022, 9, 14),
                        Rate = 6,
                        Trailer = "https://www.youtube.com/watch?v=hEqSj5esw7k",
                        Price = 150,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Producer_Id = 2,
                        Cat_Id = 5, 
                        Image = await ImageConverter("movie-3.jpg"),
                    };
                    db.Movies.Add(movie3);
                    var actors3 = new List<int> { 1, 2, 3 };
                    foreach (var id in actors3)
                    {
                        db.MovieActors.Add(new MovieActor()
                        {
                            MovieId = guid3,
                            ActorId = id
                        });
                    }
                    var cinemas3 = new List<int> { 2, 4 };
                    var quantities3 = new List<int> { 40, 60 };

                    //adding to cinema movies table
                    for (var i = 0; i < cinemas3.Count; i++)
                    {
                        db.MovieInCinemas.Add(new MovieInCinema()
                        {
                            Quantity = quantities3[i],
                            MovieId = guid3,
                            CinemaId = cinemas3[i]
                        });
                    }
                    //end of adding one movie

                    //start of adding movie
                    Guid guid4 = Guid.NewGuid();
                    var movie4 = new Movie()
                    {
                        Id = guid4,
                        Name = "Jujutsu Kaisen 0: The Movie (2021)",
                        StartDate = new DateTime(2022, 5, 30),
                        EndDate = new DateTime(2022, 10, 14),
                        Rate = 7,
                        Trailer = "https://www.youtube.com/watch?v=eGSL-l95VXw",
                        Price = 170,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Producer_Id = 2,
                        Cat_Id = 5,
                        Image = await ImageConverter("movie-4.jpg"),
                    };
                    db.Movies.Add(movie4);
                    var actors4 = new List<int> { 1, 2, 3 };
                    foreach (var id in actors4)
                    {
                        db.MovieActors.Add(new MovieActor()
                        {
                            MovieId = guid4,
                            ActorId = id
                        });
                    }
                    var cinemas4 = new List<int> { 2, 4 };
                    var quantities4 = new List<int> { 40, 60 };

                    //adding to cinema movies table
                    for (var i = 0; i < cinemas4.Count; i++)
                    {
                        db.MovieInCinemas.Add(new MovieInCinema()
                        {
                            Quantity = quantities4[i],
                            MovieId = guid4,
                            CinemaId = cinemas4[i]
                        });
                    }
                    //end of adding one movie

                }



                db.SaveChanges();
                }

            }
        


        public static async Task CreateUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "admin@emovies.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "InitialAdmin@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@emovies.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "InitialUser@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}
