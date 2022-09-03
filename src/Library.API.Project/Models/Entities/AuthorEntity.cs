using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Project.API.Models.Entities
{
    [Table("Author_Table")]
    public class AuthorEntity : PersonEntity
    {
        public ICollection<BookEntity> Books { get; set; } = default!;
    }
}
