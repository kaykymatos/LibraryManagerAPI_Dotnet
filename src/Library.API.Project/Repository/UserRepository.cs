using Library.API.Project.Data;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Repository
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
