using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Project.ViewModels
{
    [Keyless]
    public class AuthorModel
    {
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
