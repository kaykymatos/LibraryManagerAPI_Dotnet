namespace Library.Project.API.Models.DTO.Get
{
    public class AuthorDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
