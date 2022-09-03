using System.ComponentModel.DataAnnotations;

namespace Library.Project.API.Models.Entities
{
    public class UserEntity : PersonEntity
    {

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        public ICollection<BookEntity> BooksEntities { get; set; } = new List<BookEntity>();
        public ICollection<AuthorEntity> AuthorEntities { get; set; } = new List<AuthorEntity>();
    }
}
