namespace Library.Project.API.Models.DTO.Post
{
    public class BookDTOPost
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AuthorId { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
