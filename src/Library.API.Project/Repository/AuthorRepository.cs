using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models.Entities;

namespace Library.API.Project.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryAPIContext context) : base(context)
        {
        }


    }
}


