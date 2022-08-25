using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;

namespace Library.API.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public AuthorEntityModel Post(AuthorModel model)
        {
            var modelConvert = ConvertViewModelToModel(model);
            _repository.Post(modelConvert);
            return modelConvert;
        }

        public async Task<IEnumerable<AuthorEntityModel>> GetAll()
        {
            var response = await _repository.GetAll();
            return response;
        }

        public AuthorEntityModel GetById(int id)
        {
            var response = _repository.GetById(id);
            return response;
        }


        public AuthorEntityModel UpdateById(int id, AuthorModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            if (id <= 0)
                return false;

            var model = this.GetById(id);
            if (model == null)
                return false;

            _repository.Delete(model);
            return true;
        }


        public AuthorEntityModel ConvertViewModelToModel(AuthorModel model)
        {
            AuthorEntityModel entityModel = new()
            {
                Name = model.Name,
                BirthDate = model.BirthDate,
                CreatedDate = DateTime.Now
            };
            return entityModel;
        }
    }
}
