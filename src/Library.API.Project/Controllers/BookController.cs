using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
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
            var response = await _service.GetAll();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<BookEntityModel> GetBookModelById(int id)
        {
            var response = _service.GetById(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        [HttpPost]
        public ActionResult<BookEntityModel> PostBookModel(BookModel bookModel)
        {
            var response = _service.Post(bookModel);
            if (IsResponseNull(response))
                return Ok(response);

            return BadRequest(response);

        }

        [HttpDelete("{id}")]
        public ActionResult<AuthorEntityModel> DeletBookModel(int id)
        {
            var response = _service.DeleteById(id);
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
