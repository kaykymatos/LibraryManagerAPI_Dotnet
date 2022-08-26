using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models;

namespace Library.API.Project.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntityModel>, IAuthorRepository
    {
        public AuthorRepository(LibraryAPIContext context) : base(context)
        {
        }

    }
}


