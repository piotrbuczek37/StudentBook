using Microsoft.EntityFrameworkCore;
using StudentBook.API.Models;

namespace StudentBook.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
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