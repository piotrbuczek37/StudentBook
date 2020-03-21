using System;
using System.Text;
using System.Threading.Tasks;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        #region method public
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordRaw;
            CreatePasswordHashRaw(password,out passwordHash,out passwordRaw);

            user.PasswordHash = passwordHash;
            user.PasswordRaw = passwordRaw;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region method private 
        private void CreatePasswordHashRaw(string password, out byte[] passwordHash, out byte[] passwordRaw)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordRaw = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        #endregion
    }
}