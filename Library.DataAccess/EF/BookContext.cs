using Microsoft.EntityFrameworkCore;
using Library.DataAccess.Entities;

namespace Library.DataAccess.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=DESKTOP-Q68DUL9\SQLEXPRESS;Database=Library;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-Q68DUL9\\SQLEXPRESS;Database=Library;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
