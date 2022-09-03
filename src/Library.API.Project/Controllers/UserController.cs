using Library.Project.API.Interfaces.Service;
using Library.Project.API.Models.DTO.Get;
using Library.Project.API.Models.DTO.Post;
using Library.Project.API.Models.DTO.Put;
using Library.Project.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : InternalController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTOGet>>> GetAllUserModel()
        {
            var response = await _service.GetAllAsync();
            if (!IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetUserModelById(int id)
        {
            var response = await _service.GetDTOModelById(id);
            if (!IsResponseNull(response))
                return Ok(response);
            return NotFound($"Usuário não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostUserModel(UserDTOPost userModel)
        {
            var response = await _service.PostAsync(userModel);
            if (IsValidationValid(response))
                return Ok("Usuário cadastrado com sucesso!");

            return BadRequest(response);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUserModel(int id, UserDTOPut userModel)
        {
            var response = await _service.UpdateByIdAsync(id, userModel);
            if (IsValidationValid(response))
                return Ok("Usuário atualizado com sucesso!");

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletuserModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (IsValidationValid(response))
                return Ok($"Usuário deletado com sucesso!");

            return BadRequest(response);
        }
        private static bool IsValidationValid(object responseValue) => responseValue.GetType() == typeof(UserEntity);

    }
}
