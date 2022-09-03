using Library.Project.API.Data;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Project.API.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(LibraryAPIContext context) : base(context)
        {
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
            var userEntity = await _context.UserEntity!.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (userEntity == null)
                return null!;
            return userEntity;
        }
    }
}
