using FluentValidation.Results;
using Library.API.Project.Interfaces.Repository;
using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.DTO;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;

namespace Library.API.Project.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<object> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetDtoByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> PostAsync(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateByIdAsync(int id, UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
