using Library.API.Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Data
{
    public class LibraryAPIContext : DbContext
    {
        public LibraryAPIContext(DbContextOptions<LibraryAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<AuthorEntity>? AuthorEntityModel { get; set; }

        public DbSet<BookEntity>? BookEntityModel { get; set; }

        public DbSet<Library.API.Project.Models.Entities.UserEntity>? UserEntity { get; set; }
    }
}
