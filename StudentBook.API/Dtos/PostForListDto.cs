using System;

namespace StudentBook.API.Dtos
{
    public class PostForListDto
    {
        public int Id { get; set; }
        // public string Username { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
    }
}