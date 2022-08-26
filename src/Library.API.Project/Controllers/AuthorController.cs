using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models;
using Library.API.Project.Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorEntityModel>>> GetAllAuthorModels()
        {
            var response = await _service.GetAllAsync();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorEntityModel>> GetAuthorModelById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Autor não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<AuthorEntityModel>> PostAuthorModel(AuthorModel authorModel)
        {
            var response = await _service.PostAsync(authorModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);

        }
        [HttpPut]
        public async Task<ActionResult<AuthorEntityModel>> PutAuthorModel(int id, AuthorModel authorModel)
        {
            var response = await _service.UpdateByIdAsync(id, authorModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorEntityModel>> DeletAuthorModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response)
                return Ok("O Objeto foi deletado com sucesso!");

            return NotFound("Objeto nao encontrado!");
        }

        private static bool IsResponseNull(object model)
        {
            if (model == null)
                return false;

            return true;
        }

    }
}
