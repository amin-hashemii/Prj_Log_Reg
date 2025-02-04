using CoreLayer.DTO;
using DataLayer.Context;
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
            var IsFullnameexist=_context.Users.Any(u => u.UserName == registerdto.UserName);
            if (IsFullnameexist)
                OperationResult.Error("نام کاربری تکراری است");
                
            
        }
    }
}
