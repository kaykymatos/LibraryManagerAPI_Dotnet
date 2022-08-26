using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models;
using Library.API.Project.Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntityModel>>> GetAllBookModel()
        {
            var response = await _service.GetAllAsync();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntityModel>> GetBookModelById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<BookEntityModel>> PostBookModel(BookModel bookModel)
        {
            var response = await _service.PostAsync(bookModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);

        }

        [HttpPut]
        public async Task<ActionResult<BookEntityModel>> PutAuthorModel(int id, BookModel bookModel)
        {
            var response = await _service.UpdateByIdAsync(id, bookModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorEntityModel>> DeletBookModel(int id)
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
