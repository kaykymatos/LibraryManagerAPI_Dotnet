﻿namespace Library.API.Project.Models.ViewModels
{
    public class BookModel
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AuthorId { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
