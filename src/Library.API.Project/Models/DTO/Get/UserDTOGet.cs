namespace Library.Project.API.Models.DTO.Get
{
    public class UserDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
