using BookFlight.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookFlight.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<SearchModel> Search { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<BookFlightModel> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed some initial flights
            modelBuilder.Entity<BookFlightModel>().HasData(
                new BookFlightModel { Id = 1, From = "New York", To = "London", Time = "12:00 PM" },
                new BookFlightModel { Id = 2, From = "Paris", To = "Tokyo", Time = "03:30 PM" }
                // Add more flights as needed
            );

            // Define a list of 25 cities
            string[] cities = {
                "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego",
                "Dallas", "San Jose", "Austin", "Jacksonville", "San Francisco", "Indianapolis", "Columbus", "Fort Worth",
                "Charlotte", "Seattle", "Denver", "El Paso", "Detroit", "Boston", "Memphis", "Nashville", "Dubai"
            };

            // Generate and seed 23 more flights with different cities
            for (int i = 3; i <= 27; i++)
            {
                modelBuilder.Entity<BookFlightModel>().HasData(
                    new BookFlightModel
                    {
                        Id = i,
                        From = cities[i - 3],      // Choose from the list of cities
                        To = cities[i % 25],       // Ensure the "To" city is different
                        Time = $"{DateTime.Now.AddHours(i):hh:mm tt}"
                    }
                );
            }

        }
    }
}
