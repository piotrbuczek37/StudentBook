using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public interface IUserRepository : IGenericRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForUser(int userId);
    }
}