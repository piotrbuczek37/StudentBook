using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PlanetaSingli.API.Models;

namespace PlanetaSingli.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            if(!_context.Users.Any())
            {
               var userData = File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                foreach (var user in users)
                {
                byte[] passwordHash, passwordRaw;
                CreatePasswordHashRaw("password", out passwordHash,out passwordRaw);

                user.PasswordHash = passwordHash;
                user.PasswordRaw = passwordRaw;
                user.Username = user.Username.ToLower();

                _context.Users.Add(user);
                }

                 _context.SaveChanges(); 
            }

            
        }

        private void CreatePasswordHashRaw(string password, out byte[] passwordHash, out byte[] passwordRaw)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordRaw = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}