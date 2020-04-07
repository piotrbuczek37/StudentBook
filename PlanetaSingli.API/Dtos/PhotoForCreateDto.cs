using System;
using Microsoft.AspNetCore.Http;

namespace PlanetaSingli.API.Dtos
{
    public class PhotoForCreateDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public PhotoForCreateDto()
        {
            DateAdded = DateTime.Now;
        }
    }
}