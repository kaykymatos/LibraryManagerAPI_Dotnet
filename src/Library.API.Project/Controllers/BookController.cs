using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.Entities;
using Library.API.Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : InternalController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntity>>> GetAllBookModel()
        {
            var response = await _service.GetAllAsync();
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest("Nenhum resultado encontrado no banco de dados: " + response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntity>> GetBookModelById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<BookEntity>> PostBookModel(BookModel bookModel)
        {
            var response = await _service.PostAsync(bookModel);
            if (IsValidationValid(response))
                return Ok("Livro cadastrado com sucesso!");

            return BadRequest(ShowErrors(response));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookEntity>> PutAuthorModel(int id, BookModel bookModel)
        {
            var response = await _service.UpdateByIdAsync(id, bookModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorEntity>> DeletBookModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response)
                return Ok("O Objeto foi deletado com sucesso!");

            return NotFound("Objeto nao encontrado!");
        }
    }
}
