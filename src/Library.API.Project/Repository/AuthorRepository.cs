using Library.Project.API.Data;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Project.API.Repository
{
    public class AuthorRepository : BaseRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(LibraryAPIContext context) : base(context)
        {

        }

        public async Task<AuthorEntity> GetAuthorByName(string name)
        {
            var authorEntity = await _context.AuthorEntityModel!.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (authorEntity == null)
                return null!;
            return authorEntity;
        }
    }
}


