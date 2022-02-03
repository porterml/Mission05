using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission04.Models
{
    public class MovieFormContext : DbContext
    {
        // constructor- creating an instance of the database contexts
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<NewMovieForm> responses { get; set; }
        public DbSet<Category> categories { get; set; }



        protected override void OnModelCreating(ModelBuilder mb)    // protected is "as long as its in the chain"
        {
            mb.Entity<Category>().HasData(
                    new Category {CategoryID = 1,CategoryName = "Suspense"},
                    new Category {CategoryID = 2, CategoryName = "Comedy"},
                    new Category { CategoryID = 3, CategoryName = "Musical"}
                );

            mb.Entity<NewMovieForm>().HasData(

                    new NewMovieForm // seeding the data base with the following three classes
                    {
                        MovieId = 1,
                        CategoryID = 1,
                        Title = "Inception",
                        Year = 2010,
                        Director = "Christopher Nolan",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new NewMovieForm
                    {
                        MovieId = 2,
                        CategoryID = 2,
                        Title = "Free Guy",
                        Year = 2021,
                        Director = "Shawn Levy",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new NewMovieForm
                    {
                        MovieId = 3,
                        CategoryID = 3,
                        Title = "Encanto",
                        Year = 2021,
                        Director = "Byron Howard",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    }
                );
        }
    }
}
