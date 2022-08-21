using Microsoft.EntityFrameworkCore;

namespace Library.API.Data
{
    public class LibraryAPIContext : DbContext
    {
        public LibraryAPIContext(DbContextOptions<LibraryAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Library.API.Models.AuthorEntityModel>? AuthorModel { get; set; }

        public DbSet<Library.API.Models.BookEntityModel>? BookModel { get; set; }
    }
}
