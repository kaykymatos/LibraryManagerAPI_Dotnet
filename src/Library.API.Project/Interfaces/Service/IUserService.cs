using Library.API.Project.Models.DTO;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;

namespace Library.API.Project.Interfaces.Service
{
    public interface IUserService : IBaseService<UserEntity, UserModel, UserDTO>
    {
    }
}
