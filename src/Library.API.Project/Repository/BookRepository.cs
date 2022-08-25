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
            var response = await _context.BookEntityModel!.ToListAsync();
            return response;

        }

        public BookEntityModel GetById(int id)
        {
            var response = _context.BookEntityModel!.Where(x => x.Id == id).FirstOrDefault();
            return response!;
        }



        public void Update(BookEntityModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookEntityModel model)
        {
            _context.BookEntityModel!.Remove(model);
            _context.SaveChanges();
        }
    }
}
