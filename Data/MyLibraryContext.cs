using Microsoft.EntityFrameworkCore;
using MyLibrary.mvc.Models;

namespace MyLibrary.mvc.Data
{
    public class MyLibraryContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Serie> Searies { get; set; }
        
    }
}