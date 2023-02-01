using Hafta1.Odev1.RestfulApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hafta1.Odev1.RestfulApi.DbOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookStoreDb");
        }
        
    }
}
