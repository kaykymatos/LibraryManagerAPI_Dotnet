namespace Library.Project.API.Models.DTO.Put
{
    public class BookDTOPut
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime LaunchDate { get; set; }
    }
}
