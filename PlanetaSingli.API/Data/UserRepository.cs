using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanetaSingli.API.Helpers;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base (context)
        {
            _context = context;
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u => u.UserLikesId == userId && u.UserLikedId == recipientId);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(p => p.Photos).OrderByDescending(u => u.LastActive).AsQueryable();
            users = users.Where(u => u.Id != userParams.UserId);
            users = users.Where(u => u.Gender == userParams.Gender);

            if(userParams.UserLikes)
            {
                var userLikes = await GetUserLikes(userParams.UserId, userParams.UserLikes);
                users = users.Where(u => userLikes.Contains(u.Id));
            }

            if(userParams.UserLiked)
            {
                var userLiked = await GetUserLikes(userParams.UserId, userParams.UserLikes);
                users = users.Where(u => userLiked.Contains(u.Id));
            }

            if(userParams.MinAge != 18 || userParams.MaxAge != 100)
            {
                var minDate = DateTime.Today.AddYears(-userParams.MaxAge-1);
                var maxDate = DateTime.Today.AddYears(-userParams.MinAge);
                users = users.Where(u => u.DateOfBirth >= minDate && u.DateOfBirth<=maxDate);
            }

            if(userParams.ZodiacSign != "Wszystkie")
            {
                users = users.Where(u => u.ZodiacSign == userParams.ZodiacSign);
            }

            if(!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch(userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }
        
            return await PagedList<User>.CreateListAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        private async Task<IEnumerable<int>> GetUserLikes(int id, bool userLikes)
        {
            var user = await _context.Users.Include(x => x.UserLikes).Include(x => x.UserLiked).FirstOrDefaultAsync(u => u.Id == id);
            if(userLikes)
            {
                return user.UserLikes.Where(u => u.UserLikedId == id).Select(i => i.UserLikesId);
            }
            return user.UserLiked.Where(u => u.UserLikesId == id).Select(i => i.UserLikedId);
        }
    }
}