using System;
using Newtonsoft.Json;

namespace PlanetaSingli.API.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string public_id {get; set;}


        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}