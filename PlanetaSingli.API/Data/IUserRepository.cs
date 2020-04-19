using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetaSingli.API.Helpers;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public interface IUserRepository : IGenericRepository
    {
         Task<PagedList<User>> GetUsers(UserParams userParams);
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
         Task<Like> GetLike(int userId, int recipientId);
    }
}