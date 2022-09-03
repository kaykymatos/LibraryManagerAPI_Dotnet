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
    public class AuthorController : InternalController
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTOGet>>> GetAllAuthorModels()
        {
            var response = await _service.GetAllAsync();
            if (!IsResponseNull(response))
                return Ok(response);

            return BadRequest("Nenhum resultado encontrado no banco de dados: " + response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetAuthorModelById(int id)
        {
            var response = await _service.GetDTOModelById(id);
            if (!IsResponseNull(response))
                return Ok(response);
            return NotFound($"Autor não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTOPost>> PostAuthorModel(AuthorDTOPost authorModel)
        {
            var response = await _service.PostAsync(authorModel);
            if (IsValidationValid(response))
                return Ok("Autor cadastrado com sucesso!");

            return BadRequest(response);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutAuthorModel(int id, AuthorDTOPut authorModel)
        {
            var response = await _service.UpdateByIdAsync(id, authorModel);
            if (IsValidationValid(response))
                return Ok("Author Atualizado com sucesso!");

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletAuthorModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (IsValidationValid(response))
                return Ok($"Author deletado com sucesso!");

            return BadRequest(response);
        }
        private static bool IsValidationValid(object responseValue) => responseValue.GetType() == typeof(AuthorEntity);
    }
}
