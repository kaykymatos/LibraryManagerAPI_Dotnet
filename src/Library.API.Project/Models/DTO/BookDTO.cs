﻿namespace Library.API.Project.Models.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LaunchDate { get; set; }

    }
}
