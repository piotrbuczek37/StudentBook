using System;
using System.ComponentModel.DataAnnotations;

namespace PlanetaSingli.API.Dtos
{
    public class PostForCreateDto
    {
        [Required]
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public int UserId { get; set; }

        public PostForCreateDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}