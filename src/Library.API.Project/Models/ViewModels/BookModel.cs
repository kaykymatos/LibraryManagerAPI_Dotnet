using Microsoft.EntityFrameworkCore;

namespace Library.API.Project.Models.ViewModels
{
    [Keyless]
    public class BookModel
    {
        public string Title { get; set; } = default!;
        public string BookDescription { get; set; } = default!;
        public int AuthorId { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
