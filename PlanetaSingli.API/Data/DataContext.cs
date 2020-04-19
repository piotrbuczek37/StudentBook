using Microsoft.EntityFrameworkCore;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>().HasKey(k => new {k.UserLikesId, k.UserLikedId});
            builder.Entity<Like>().HasOne(u => u.UserLiked)
                                    .WithMany(u => u.UserLikes)
                                    .HasForeignKey(u => u.UserLikedId)
                                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Like>().HasOne(u => u.UserLikes)
                                    .WithMany(u => u.UserLiked)
                                    .HasForeignKey(u => u.UserLikesId)
                                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}