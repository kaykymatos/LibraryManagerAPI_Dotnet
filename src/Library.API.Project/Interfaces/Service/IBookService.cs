using Library.API.Models;
using Library.API.Project.Interfaces.Service;
using Library.API.ViewModels;

namespace Library.API.Interfaces.Service
{
    public interface IBookService : IBaseService<BookEntityModel, BookModel>
    {
        BookEntityModel Post(BookModel entity);

        BookEntityModel UpdateById(int id, BookModel entity);
    }
}
