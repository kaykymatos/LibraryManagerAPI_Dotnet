using Library.API.Interfaces.Service;
using Library.API.Models;
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
            return Ok(response);
        }

        // GET: api/AuthorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorEntityModel>> GetAuthorModelById(int id)
        {
            var response = await _service.GetById(id);
            if (response == null)
                return BadRequest("Nenhum autor foi encontrado com esse id!");

            return Ok(response);
        }

        // POST: api/AuthorModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<AuthorEntityModel> PostAuthorModel(AuthorEntityModel authorModel)
        {
            var response = _service.Post(authorModel);

            return Ok(response);
        }

    }
}
