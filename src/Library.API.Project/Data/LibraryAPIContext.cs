using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data
{
    public class LibraryAPIContext : DbContext
    {
        public LibraryAPIContext(DbContextOptions<LibraryAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntityModel>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Library.API.Models.AuthorEntityModel>? AuthorEntityModel { get; set; }

        public DbSet<Library.API.Models.BookEntityModel>? BookEntityModel { get; set; }
    }
}
