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
            var response = await _context.AuthorEntityModel!.ToListAsync();
            return response;

        }

        public AuthorEntityModel GetById(int id)
        {
            var response = _context.AuthorEntityModel!.Where(x => x.Id == id).FirstOrDefault();
            return response!;
        }

        public void Update(AuthorEntityModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(AuthorEntityModel model)
        {
            _context.AuthorEntityModel!.Remove(model);
            _context.SaveChanges();
        }

    }
}
