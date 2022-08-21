using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Models
{
    public class BookEntityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Title { get; set; } = default!;
        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string BookDescription { get; set; } = default!;
        [Required]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [JsonIgnore]
        private AuthorEntityModel Author { get; set; } = default!;
        public DateTime LaunchDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
