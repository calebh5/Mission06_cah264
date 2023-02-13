using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_cah264.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<FormResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FormResponse>().HasData(

                new FormResponse
                {
                    MovieID = 1,
                    Category = "Sci-fi/Adventure",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG13"
                },

                new FormResponse
                {
                    MovieID = 2,
                    Category = "Comedy",
                    Title = "Napoleon Dynamite",
                    Year = 2004,
                    Director = "Jared Hess",
                    Rating = "PG"
                },

                new FormResponse
                {
                    MovieID = 3,
                    Category = "War/Drama",
                    Title = "Hacksaw Ridge",
                    Year = 2016,
                    Director = "Mel Gibson",
                    Rating = "R"
                }
            );
        }
    }
}
