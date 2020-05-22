using System.Collections.Generic;
using System.Threading.Tasks;
using StudentBook.API.Helpers;
using StudentBook.API.Models;

namespace StudentBook.API.Data
{
    public interface IUserRepository : IGenericRepository
    {
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         Task<Like> GetLike(int userId, int recipientId);
         Task<Post> GetPost(int id);
         Task<IEnumerable<Post>> GetPosts();
    }
}