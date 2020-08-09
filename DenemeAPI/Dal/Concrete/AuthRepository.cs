using Dal.Abstract;
using Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private Context _context;
        public AuthRepository(Context context)
        {
            _context = context;
        }

        public void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.Where(i => i.ID == id).FirstOrDefault();
            return user;
        }

        public User Login(Login loginuser) // ---> Login is in UserDTO.
        {
            var user = _context.Users.Where(i => i.UserName == loginuser.UserName).FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            
            if(VerifyPassword(loginuser.Password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }

        public bool Register(Register registeruser) // ---> Register is in UserDTO.
        {
            if (UserExist(registeruser) && registeruser != null)
            {
                var user = new User();
                CreateHash(registeruser.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.UserName = registeruser.UserName;
                user.Email = registeruser.Email;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UserExist(Register registeruser)
        {
            var exist = _context.Users.Any
                (i => i.UserName == registeruser.UserName || i.Email == registeruser.Email);
            if(exist == false)
            {
                return true;
            }
            return false;
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + passwordSalt));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if(computeHash[i] == passwordHash[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
