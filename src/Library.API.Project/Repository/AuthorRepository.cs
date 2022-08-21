using Library.API.Data;
using Library.API.Interfaces.Repository;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryAPIContext _context;
        public AuthorRepository(LibraryAPIContext context)
        {
            _context = context;
        }

        public void Post(AuthorEntityModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<AuthorEntityModel>> GetAll()
        {
            var response = await _context.AuthorModel!.ToListAsync();

            return response;

        }

        public async Task<AuthorEntityModel> GetById(int id)
        {
            var response = await _context.AuthorModel!.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (response == null)
                return new AuthorEntityModel();
            return response;
        }
    }
}
