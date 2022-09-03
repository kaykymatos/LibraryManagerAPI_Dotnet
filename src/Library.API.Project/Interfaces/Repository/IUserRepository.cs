using Library.Project.API.Models.Entities;

namespace Library.Project.API.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetUserByEmail(string email);
    }
}
