using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Username == username);

            if(user==null){
                return null;
            }

            if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordRaw)){
                return null;
            }
            return user;
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

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username == username)){
                return true;
            }
            return false;
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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordRaw)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordRaw)){
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i = 0;i<computedHash.Length;i++){
                    if(computedHash[i] != passwordHash[i]){
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion
    }
}