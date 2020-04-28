using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public interface IPostRepository : IGenericRepository
    {
         Task<IEnumerable<Post>> GetPosts();
         Task<Post> GetPost(int id);
         Task<User> GetUser(int id);
    }
}