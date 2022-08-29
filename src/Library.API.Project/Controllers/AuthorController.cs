using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.DTO;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Project.Controllers
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
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorModels()
        {
            var response = await _service.GetAllAsync();
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest("Nenhum resultado encontrado no banco de dados: " + response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorModelById(int id)
        {
            var response = await _service.GetDtoByAsync(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Autor não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<AuthorEntity>> PostAuthorModel(AuthorModel authorModel)
        {
            var response = await _service.PostAsync(authorModel);
            if (IsValidationValid(response))
                return Ok("Autor cadastrado com sucesso!");

            return BadRequest(ShowErrors(response));

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutAuthorModel(int id, AuthorModel authorModel)
        {
            var response = await _service.UpdateByIdAsync(id, authorModel);
            if (response.GetType() == typeof(AuthorEntity))
                return Ok("Author Atualizado com sucesso!");

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletAuthorModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response.GetType() == typeof(AuthorEntity))
                return Ok($"Author deletado com sucesso!");

            return BadRequest(response);
        }
    }
}
