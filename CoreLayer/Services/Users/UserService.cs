using CoreLayer.DTO;
using DataLayer.Context;
using DataLayer.Entity;
using Prj_Log_Reg.CoreLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
    public class UserService : IUserService
        
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

       

        public OperationResult RegisterUser(UserRegisterDto registerdto)
        {
            var IsUserNameExists=_context.Users.Any(u => u.UserName == registerdto.UserName);
            if (IsUserNameExists)
              return  OperationResult.Error("نام کاربری تکراری است");

            var passwordhash = registerdto.PassWord.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerdto.FullName,
                IsDelete = false,
                UserName = registerdto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordhash
            });
            _context.SaveChanges();
           return OperationResult.Success();
        }
        public UserDTO LoginUser(UserLoginDto logindto)
        {
            var passwordhashed = logindto.PassWord.EncodeToMd5();
            var user = _context.Users.FirstOrDefault(u => u.UserName == logindto.UserName && u.Password == passwordhashed);

            if (user == null)
                return null;

            var userdto = new UserDTO()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserId = user.Id,
            };
            return userdto;
        }
    }
}
