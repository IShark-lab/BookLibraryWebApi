using Microsoft.EntityFrameworkCore;
using Library.DataAccess.Entities;

namespace Library.DataAccess.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
