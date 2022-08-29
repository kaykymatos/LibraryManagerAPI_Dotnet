using Library.API.Project.Interfaces.Service;
using Library.API.Project.Models.DTO;
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
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBookModel()
        {
            var response = await _service.GetAllAsync();
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBookModelById(int id)
        {
            var response = await _service.GetDtoByAsync(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostBookModel(BookModel bookModel)
        {
            var response = await _service.PostAsync(bookModel);
            if (IsValidationValid(response))
                return Ok("Livro cadastrado com sucesso!");

            return BadRequest(ShowErrors(response));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutAuthorModel(int id, BookModel bookModel)
        {
            var response = await _service.UpdateByIdAsync(id, bookModel);
            if (response.GetType() == typeof(BookEntity))
                return Ok("Livro atualizado com sucesso!");

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletBookModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response.GetType() == typeof(BookEntity))
                return Ok($"Livro deletado com sucesso!");

            return BadRequest(response);
        }
    }
}
