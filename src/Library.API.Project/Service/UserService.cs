using AutoMapper;
using Library.Project.API.Interfaces.Repository;
using Library.Project.API.Interfaces.Service;
using Library.Project.API.Models.DTO.Get;
using Library.Project.API.Models.DTO.Post;
using Library.Project.API.Models.DTO.Put;
using Library.Project.API.Models.Entities;
using Library.Project.API.Validation.ValidationModels.BusinessValidation;
using Library.Project.API.Validation.ValidationModels.EntityValidation;

namespace Library.Project.API.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTOGet> GetDTOModelById(int id)
        {
            var dtoModel = await GetEntityById(id);
            if (dtoModel == null)
                return null!;
            return _mapper.Map<UserDTOGet>(dtoModel);
        }
        public async Task<UserEntity> GetEntityById(int id)
        {
            var entity = await _userRepository.GetEntityByIdAsync(id);
            if (entity == null)
                return null!;
            return entity;
        }
        public async Task<IEnumerable<UserDTOGet>> GetAllAsync()
        {
            var response = await _userRepository.GetAllAsync();
            List<UserDTOGet> listDTO = new();
            foreach (var entity in response)
            {
                var convertModelToDTO = _mapper.Map<UserDTOGet>(entity);
                listDTO.Add(convertModelToDTO);
            }
            return listDTO;
        }
        public async Task<object> PostAsync(UserDTOPost model)
        {
            var convertModelToEntity = _mapper.Map<UserEntity>(model);

            var validation = new UserValidation(false).Validate(convertModelToEntity);
            var businessValidation = new UserBusinessValidation(_userRepository, false).Validate(convertModelToEntity);

            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businessValidation.IsValid)
                return businessValidation.Errors.Select(x => x.ErrorMessage).ToList();

            convertModelToEntity.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            convertModelToEntity.BirthDate = DateTime.Parse(model.BirthDate.ToString("dd-MM-yyyy HH:mm:ss"));

            var postEntityModel = await _userRepository.PostAsync(convertModelToEntity);
            return postEntityModel;
        }
        public async Task<object> UpdateByIdAsync(int id, UserDTOPut model)
        {
            var converteModelToEntity = _mapper.Map<UserEntity>(model);

            var verification = await ValidationOnUpdateModel(id, converteModelToEntity);
            if (verification.Any())
                return verification;

            var response = await _userRepository.UpdateAsync(id, converteModelToEntity);
            return response;
        }
        public async Task<object> DeleteByIdAsync(int id)
        {
            var findUserEntity = await _userRepository.GetEntityByIdAsync(id);
            if (findUserEntity == null)
                return "Usuário nao encontrado!";

            var response = await _userRepository.DeleteAsync(findUserEntity);
            return response;
        }

        public async Task<List<string>> ValidationOnUpdateModel(int id, UserEntity model)
        {
            List<string> errors = new();
            var findUserEntity = await _userRepository.GetEntityByIdAsync(id);
            if (findUserEntity == null)
            {
                errors.Add("Usuário nao encontrado");
                return errors;
            }

            model.Id = id;
            model.CreatedDate = DateTime.Parse(findUserEntity.CreatedDate.ToString("dd-MM-yyyy HH:mm:ss"));
            model.Email = findUserEntity.Email;

            model.BirthDate = DateTime.Parse(model.BirthDate.ToString("dd-MM-yyyy HH:mm:ss"));

            var validation = new UserValidation(true).Validate(model);
            var businessValidation = new UserBusinessValidation(_userRepository, true).Validate(model);
            if (!validation.IsValid)
                return validation.Errors.Select(x => x.ErrorMessage).ToList();

            if (!businessValidation.IsValid)
                return businessValidation.Errors.Select(x => x.ErrorMessage).ToList();

            return new List<string>();
        }

    }
}
