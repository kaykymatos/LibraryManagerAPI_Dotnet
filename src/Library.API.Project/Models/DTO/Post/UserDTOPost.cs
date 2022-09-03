namespace Library.Project.API.Models.DTO.Post
{
    public class UserDTOPost
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string Password { get; set; } = default!;
    }
}
