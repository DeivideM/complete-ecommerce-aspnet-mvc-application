using eTickets.Data.Enums;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            context.Database.EnsureCreated();
            // Cinema
            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddRange(new List<Cinema>()
                {
                    new () { Name = "Cinema 1", Logo = "https://dotnethow.net/images/cinemas/cinema-1.jpeg", Description = "This is the description of the first cinema" },
                    new () { Name = "Cinema 2", Logo = "https://dotnethow.net/images/cinemas/cinema-2.jpeg", Description = "This is the description of the second cinema" },
                    new () { Name = "Cinema 3", Logo = "https://dotnethow.net/images/cinemas/cinema-3.jpeg", Description = "This is the description of the third cinema" },
                    new () { Name = "Cinema 4", Logo = "https://dotnethow.net/images/cinemas/cinema-4.jpeg", Description = "This is the description of the fourth cinema" },
                    new () { Name = "Cinema 5", Logo = "https://dotnethow.net/images/cinemas/cinema-5.jpeg", Description = "This is the description of the fifth cinema" },
                });
                context.SaveChanges();
            }
            //Actor
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                {
                    new () { FullName = "Actor 1", Bio = "This is the bio of the first actor", ProfilePictureURL = "https://dotnethow.net/images/actors/actor-1.jpeg" },
                    new () { FullName = "Actor 2", Bio = "This is the bio of the second actor", ProfilePictureURL = "https://dotnethow.net/images/actors/actor-2.jpeg" },
                    new () { FullName = "Actor 3", Bio = "This is the bio of the third actor", ProfilePictureURL = "https://dotnethow.net/images/actors/actor-3.jpeg" },
                    new () { FullName = "Actor 4", Bio = "This is the bio of the fourth actor", ProfilePictureURL = "https://dotnethow.net/images/actors/actor-4.jpeg" },
                    new () { FullName = "Actor 5", Bio = "This is the bio of the fifth actor", ProfilePictureURL = "https://dotnethow.net/images/actors/actor-5.jpeg" },
                });
                context.SaveChanges();
            }

            //Producer
            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>()
                {
                    new () { FullName = "Producer 1", Bio = "This is the bio of the first producer", ProfilePictureURL = "https://dotnethow.net/images/producers/producer-1.jpeg" },
                    new () { FullName = "Producer 2", Bio = "This is the bio of the second producer", ProfilePictureURL = "https://dotnethow.net/images/producers/producer-2.jpeg" },
                    new () { FullName = "Producer 3", Bio = "This is the bio of the third producer", ProfilePictureURL = "https://dotnethow.net/images/producers/producer-3.jpeg" },
                    new () { FullName = "Producer 4", Bio = "This is the bio of the fourth producer", ProfilePictureURL = "https://dotnethow.net/images/producers/producer-4.jpeg" },
                    new () { FullName = "Producer 5", Bio = "This is the bio of the fifth producer", ProfilePictureURL = "https://dotnethow.net/images/producers/producer-5.jpeg" },
                });
                context.SaveChanges();
            }

            //Movie
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                {
                    new () { Name = "Movie 1", Description = "This is the description of the first movie", Price = 39.50, ImageURL = "https://dotnethow.net/images/movies/movie-1.jpeg", StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(20), CinemaId = 1, ProducerId = 1, MovieCategory = MovieCategory.Action },
                    new () { Name = "Movie 2", Description = "This is the description of the second movie", Price = 29.50, ImageURL = "https://dotnethow.net/images/movies/movie-2.jpeg", StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(25), CinemaId = 2, ProducerId = 2, MovieCategory = MovieCategory.Comedy },
                    new () { Name = "Movie 3", Description = "This is the description of the third movie", Price = 39.50, ImageURL = "https://dotnethow.net/images/movies/movie-3.jpeg", StartDate = DateTime.Now.AddDays(-15), EndDate = DateTime.Now.AddDays(15), CinemaId = 3, ProducerId = 3, MovieCategory = MovieCategory.Drama },
                    new () { Name = "Movie 4", Description = "This is the description of the fourth movie", Price = 24.50, ImageURL = "https://dotnethow.net/images/movies/movie-4.jpeg", StartDate = DateTime.Now.AddDays(-20), EndDate = DateTime.Now.AddDays(10), CinemaId = 4, ProducerId = 4, MovieCategory = MovieCategory.Horror },
                    new () { Name = "Movie 5", Description = "This is the description of the fifth movie", Price = 34.50, ImageURL = "https://dotnethow.net/images/movies/movie-5.jpeg", StartDate = DateTime.Now.AddDays(-8), EndDate = DateTime.Now.AddDays(22), CinemaId = 5, ProducerId = 5, MovieCategory = MovieCategory.Cartoon },
                });
                context.SaveChanges();

            }

            //Actor_Movie
            if (!context.Actors_Movies.Any())
            {
                context.Actors_Movies.AddRange(new List<Actors_Movies>()
                {
                    new() { ActorId = 1, MovieId = 1 },
                    new() { ActorId = 3, MovieId = 1 },
                    new() { ActorId = 2, MovieId = 2 },
                    new() { ActorId = 4, MovieId = 2 },
                    new() { ActorId = 5, MovieId = 3 },
                    new() { ActorId = 1, MovieId = 3 },
                    new() { ActorId = 2, MovieId = 4 },
                    new() { ActorId = 3, MovieId = 4 },
                    new() { ActorId = 4, MovieId = 5 },
                    new() { ActorId = 5, MovieId = 5 },
                });
                context.SaveChanges();
            }
        }
    }

    public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
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
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "admin@tickets.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    Fullname = "Admin User",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            
            string appUserEmail = "user@tickets.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    Fullname = "Application User",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}
