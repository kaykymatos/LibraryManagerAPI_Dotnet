using Microsoft.EntityFrameworkCore;

namespace Library.API.ViewModels
{
    [Keyless]
    public class AuthorModel
    {
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
