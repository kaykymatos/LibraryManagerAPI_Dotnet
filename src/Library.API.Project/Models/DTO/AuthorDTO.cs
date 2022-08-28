namespace Library.API.Project.Models.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
