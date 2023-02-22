using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Model with prebuilt movies. Seeded with the first 3 of the database
namespace Mission06_cah264.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<FormResponse> responses { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Sci-fi/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "War/Drama" },
                new Category { CategoryID = 4, CategoryName = "Action" },
                new Category { CategoryID = 5, CategoryName = "Boring" }
                );

            mb.Entity<FormResponse>().HasData(

                new FormResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG13"
                },

                new FormResponse
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG"
                },

                new FormResponse
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "Hacksaw Ridge",
                    Year = 2016,
                    Director = "Mel Gibson",
                    Rating = "R"
                }
            );
        }
    }
}
