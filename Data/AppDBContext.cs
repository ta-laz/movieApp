using Microsoft.EntityFrameworkCore;
using movieApp.Models;

namespace movieApp.Data
{
    public class AppDbContext : DbContext       //dbcontext respresents the conection with a database and the mix
    {
        //this is a constructor (??)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Console.Write("");
        }

        public DbSet<Movie> Movies { get; set; }        //I want to store a table of Movie object (defined elsewhere)
    }
}
