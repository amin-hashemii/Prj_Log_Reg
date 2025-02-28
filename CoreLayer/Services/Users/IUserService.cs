
using CoreLayer.DTO;
using Prj_Log_Reg.CoreLayer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto registerdto);
        UserDTO LoginUser(UserLoginDto logindto);
    }
}
