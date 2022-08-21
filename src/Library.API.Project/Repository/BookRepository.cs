using Library.API.Data;
using Library.API.Interfaces.Repository;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryAPIContext _context;
        public BookRepository(LibraryAPIContext context)
        {
            _context = context;
        }

        public void Post(BookEntityModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<BookEntityModel>> GetAll()
        {
            var response = await _context.BookModel!.ToListAsync();          
            return response;

        }

        public async Task<BookEntityModel> GetById(int id)
        {
            var response = await _context.BookModel!.Where(x => x.Id == id).FirstOrDefaultAsync();           
            return response;
        }

        public async void UpdateModel(BookEntityModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }
        }
    }
}
