using System.ComponentModel.DataAnnotations;

namespace Library.API.Project.Models.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public ICollection<BookEntity> BooksEntities { get; set; } = new List<BookEntity>();
        public ICollection<AuthorEntity> AuthorEntities { get; set; } = new List<AuthorEntity>();
    }
}
