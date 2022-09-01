using Library.API.Project.Models.Entities;

namespace Library.API.Project.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetUserByEmail(string email);
    }
}
