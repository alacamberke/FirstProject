using Dtos;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IAuthRepository
    {
        bool Register(Register registeruser);
        User Login(Login loginuser);
        bool UserExist(Register registeruser);
        void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
        List<User> GetAllUsers();
        User GetUser(int id);
    }
}
