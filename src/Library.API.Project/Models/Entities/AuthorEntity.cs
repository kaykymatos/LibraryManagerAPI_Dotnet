using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Project.Models.Entities
{
    [Table("Author_Table")]
    public class AuthorEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; } = default!;
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<BookEntity> Books { get; set; } = default!;
    }
}
