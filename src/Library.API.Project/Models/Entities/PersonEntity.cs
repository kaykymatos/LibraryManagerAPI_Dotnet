using System.ComponentModel.DataAnnotations;

namespace Library.Project.API.Models.Entities
{
    public class PersonEntity
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
        public DateTime CreatedDate { get; set; }
    }
}
