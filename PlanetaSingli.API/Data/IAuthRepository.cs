using System.Threading.Tasks;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Login(string username, string password);
         Task<User> Register(User user, string password);
         Task<bool> UserExists(string username);
    }
}