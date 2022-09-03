using Library.Project.API.Data;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Project.API.Repository
{
    public class BookRepository : BaseRepository<BookEntity>, IBookRepository
    {
        public BookRepository(LibraryAPIContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id)
        {
            var listBooksEntity = await base._context.BookEntityModel!.Where(x => x.AuthorId == id).ToListAsync();
            return listBooksEntity;
        }
    }
}
