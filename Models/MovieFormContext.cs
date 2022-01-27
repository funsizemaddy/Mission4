using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieFormContext : DbContext
    {
        //Contrustor
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {

        }
        public DbSet<Movie_app_response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie_app_response>().HasData(
                new Movie_app_response 
                { 
                    MovieID = 1,
                    Category = "Action/Sci-fi",
                    Title = "Battleship",
                    Director = "Peter Berg",
                    Rating = "PG-13"
                },
                new Movie_app_response
                { 
                    MovieID = 2,
                    Category = "Animated Musical Fantasy Comedy-Drama",
                    Title = "Brother Bear",
                    Director = "Aaron Blaise, Robert Walker",
                    Rating = "G"

                },
                new Movie_app_response
                {
                    MovieID = 3,
                    Category = "Romance",
                    Title = "Safe Haven",
                    Director = "Lasse Stevens",
                    Rating = "PG-13",
                }
                );
        }
            }  

    
}
