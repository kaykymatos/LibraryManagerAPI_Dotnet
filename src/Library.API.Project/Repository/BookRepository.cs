using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models;

namespace Library.API.Project.Repository
{
    public class BookRepository : BaseRepository<BookEntityModel>, IBookRepository
    {
        public BookRepository(LibraryAPIContext context) : base(context)
        {
        }
    }
}
