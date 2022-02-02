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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie_app_response>().HasData(
                new Movie_app_response 
                { 
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "Battleship",
                    Year = 2012 ,
                    Director = "Peter Berg",
                    Rating = "PG-13"
                },
                new Movie_app_response
                { 
                    MovieID = 2,
                    CategoryId = 4,
                    Title = "Brother Bear",
                    Year = 2003,
                    Director = "Aaron Blaise, Robert Walker",
                    Rating = "G"

                },
                new Movie_app_response
                {
                    MovieID = 3,
                    CategoryId = 3,
                    Title = "Safe Haven",
                    Year = 2013,
                    Director = "Lasse Stevens",
                    Rating = "PG-13",
                }
                );
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );
        }
            }  

    
}
