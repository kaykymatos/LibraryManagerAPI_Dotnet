using Library.API.Models;
using Library.API.Project.Interfaces.Repository;

namespace Library.API.Interfaces.Repository
{
    public interface IBookRepository: IBaseRepository<BookEntityModel>
    {
    }
}
