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

        // GET: api/AuthorModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorEntityModel>>> GetAllAuthorModels()
        {
            var response = await _service.GetAll();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        // GET: api/AuthorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorEntityModel>> GetAuthorModelById(int id)
        {
            var response = await _service.GetById(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Autor não encontrado com o Id {id}!");
        }

        // POST: api/AuthorModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<AuthorEntityModel> PostAuthorModel(AuthorViewModel authorModel)
        {
            var response = _service.Post(authorModel);
            return Ok(response);
        }

        private bool IsResponseNull(object model)
        {
            if (model == null)
                return false;

            return true;
        }

    }
}
