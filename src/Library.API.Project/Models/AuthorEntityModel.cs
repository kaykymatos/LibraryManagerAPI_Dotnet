using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Models
{
    [Table("Author_Table")]
    public class AuthorEntityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
