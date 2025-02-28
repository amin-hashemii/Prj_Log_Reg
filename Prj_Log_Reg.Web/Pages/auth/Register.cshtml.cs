using CoreLayer.DTO;
using CoreLayer.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prj_Log_Reg.CoreLayer.Utility;
using System.ComponentModel.DataAnnotations;

namespace Prj_Log_Reg.Web.Pages.auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userservice;
     
      
        #region propertis

        [Display(Name = "??? ??????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string UserName { get; set; }

        [Display(Name = "??? ? ??? ????????")]
        [Required(ErrorMessage = "{0} ?? ???? ????")]
        public string FullName { get; set; }

        [Display(Name = "???? ????")]
        [Required(ErrorMessage = "{0}?? ???? ????")]
        [MinLength(6, ErrorMessage = "{0}  ???? ????? ??5 ?????? ????")]
        public string Password { get; set; }


        #endregion
        public RegisterModel(IUserService userservice)
        {
            _userservice = userservice;
        }


        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            var resault = _userservice.RegisterUser(new UserRegisterDto()
            {
                UserName = UserName,
                PassWord = Password,
                FullName = FullName

            });
            if (resault.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("UserName", resault.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}