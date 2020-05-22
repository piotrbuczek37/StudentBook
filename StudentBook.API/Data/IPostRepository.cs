using System.Collections.Generic;
using System.Threading.Tasks;
using StudentBook.API.Models;

namespace StudentBook.API.Data
{
    public interface IPostRepository : IGenericRepository
    {
         Task<IEnumerable<Post>> GetPosts();
         Task<Post> GetPost(int id);
         Task<User> GetUser(int id);
    }
}