using Library.API.Interfaces.Service;
using Library.API.Models;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntityModel>>> GetAllBookModel()
        {
            var response = await _service.GetAll();
            if (IsResponseNull(response))
                return Ok(response);

            return NoContent();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntityModel>> GetBookModelById(int id)
        {
            var response = await _service.GetById(id);
            if (IsResponseNull(response))
                return Ok(response);
            return NotFound($"Livro não encontrado com o Id {id}!");
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BookEntityModel> PostBookModel(BookViewModel bookModel)
        {
            var response = _service.Post(bookModel);
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
