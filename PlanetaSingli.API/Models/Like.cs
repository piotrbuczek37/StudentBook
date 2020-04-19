namespace PlanetaSingli.API.Models
{
    public class Like
    {
        public int UserLikesId { get; set; } // użytkownik lubi
        public int UserLikedId { get; set; } // użytkownik polubiony
        public User UserLikes { get; set; }
        public User UserLiked { get; set; }
    }
}