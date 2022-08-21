using Library.API.Interfaces.Service;
using Library.API.Models;
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

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntityModel>>> GetAllBookModel()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntityModel>> GetBookModelById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<BookEntityModel> PostBookModel(BookEntityModel bookModel)
        {
            var response = _service.Post(bookModel);
            return Ok(response);
        }

    }
}
