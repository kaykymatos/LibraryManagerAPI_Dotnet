namespace Library.Project.API.Models.DTO.Put
{
    public class UserDTOPut
    {
        public string Name { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string Password { get; set; } = default!;
    }
}
