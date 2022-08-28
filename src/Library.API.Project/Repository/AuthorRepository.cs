using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryAPIContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookEntity>> GetAllAuthorBooksByAuthorId(int id)
        {
            var listBooksEntity = await base._context.BookEntityModel!.Where(x => x.AuthorId == id).ToListAsync();
            return listBooksEntity;
        }
    }
}


