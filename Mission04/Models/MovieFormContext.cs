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

        protected override void OnModelCreating(ModelBuilder mb)    // protected is "as long as its in the chain"
        {
            mb.Entity<NewMovieForm>().HasData(

                    new NewMovieForm // seeding the data base with the following three classes
                    {
                        MovieId = 1,
                        Category = "Suspense",
                        Title = "Inception",
                        Year = 2010,
                        Director = "Christopher Nolan",
                        Rating = "8.8/10",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new NewMovieForm
                    {
                        MovieId = 2,
                        Category = "Comedy",
                        Title = "Free Guy",
                        Year = 2021,
                        Director = "Shawn Levy",
                        Rating = "7.2/10",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    },
                    new NewMovieForm
                    {
                        MovieId = 3,
                        Category = "Musical",
                        Title = "Encanto",
                        Year = 2021,
                        Director = "Byron Howard",
                        Rating = "7.3/10",
                        Edited = false,
                        LentTo = "",
                        Notes = ""
                    }
                );
        }
    }
}
