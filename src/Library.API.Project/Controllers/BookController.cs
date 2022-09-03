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
    public class BookController : InternalController
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTOGet>>> GetAllBookModel()
        {
            var response = await _service.GetAllAsync();
            if (!IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetBookModelById(int id)
        {
            var response = await _service.GetDTOModelById(id);
            if (!IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostBookModel(BookDTOPost bookModel)
        {
            var response = await _service.PostAsync(bookModel);
            if (IsValidationValid(response))
                return Ok("Livro cadastrado com sucesso!");

            return BadRequest(response);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutBookModel(int id, BookDTOPut bookModel)
        {
            var response = await _service.UpdateByIdAsync(id, bookModel);
            if (IsValidationValid(response))
                return Ok("Livro atualizado com sucesso!");

            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> DeletBookModel(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (IsValidationValid(response))
                return Ok($"Livro deletado com sucesso!");

            return BadRequest(response);
        }
        private static bool IsValidationValid(object responseValue) => responseValue.GetType() == typeof(BookEntity);
    }
}
