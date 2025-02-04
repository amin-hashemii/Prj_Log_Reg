
using Prj_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prj_Blog.CoreLayer.DTOs.Users;
using Prj_Blog.CoreLayer.Services.Users;

//using Prj_Blog.CoreLayer.DTOs;
//using Prj_Blog.CoreLayer.Services.Users;
//using Prj_Blog.CoreLayer.Utities;
using System.ComponentModel.DataAnnotations;

namespace Prj_Blog.Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;


        #region propertis

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        [MinLength(6, ErrorMessage = "{0}  باید بیشتز از5 کارکتر باشد")]
        public string Password { get; set; }


        #endregion

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _userService.RegisterUser(new UserRegisterDto()
            {
                UserName = UserName,
                Password = Password,
                FullName = FullName
            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
          return RedirectToPage("Login");
        }




    }
    }

