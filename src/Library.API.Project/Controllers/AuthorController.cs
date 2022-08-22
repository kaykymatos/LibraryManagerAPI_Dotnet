using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
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
            var response = await _service.GetAll();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorEntityModel> GetAuthorModelById(int id)
        {
            var response = _service.GetById(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Autor não encontrado com o Id {id}!");
        }

        [HttpPost]
        public ActionResult<AuthorEntityModel> PostAuthorModel(AuthorViewModel authorModel)
        {
            var response = _service.Post(authorModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<AuthorEntityModel> DeletAuthorModel(int id)
        {
            var response = _service.DeleteById(id);
            if (response)
                return Ok("O Objeto foi deeltado com sucesso!");

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
