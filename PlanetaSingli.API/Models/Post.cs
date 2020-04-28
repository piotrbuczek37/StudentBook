using System;

namespace PlanetaSingli.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
    }
}