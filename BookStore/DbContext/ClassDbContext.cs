
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public  DbSet<Genre> Genres { get; set; }


    }
}
    