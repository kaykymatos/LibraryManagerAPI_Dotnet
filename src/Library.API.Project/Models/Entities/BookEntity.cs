using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Project.API.Models.Entities
{
    [Table("Books_Table")]
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Title { get; set; } = default!;
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Description { get; set; } = default!;
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; } = default!;
        public DateTime LaunchDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
