namespace Library.API.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; } = default!;
        public string BookDescription { get; set; } = default!;
        public int AuthorId { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
