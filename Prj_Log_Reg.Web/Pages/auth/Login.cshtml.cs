using CoreLayer.DTO;
using CoreLayer.Services.Users;
using DataLayer.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Prj_Log_Reg.CoreLayer.Utility;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Prj_Log_Reg.Web.Pages.auth
{
    [BindProperties]
   
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [Required(ErrorMessage = " ??? ?????? ?? ???? ????")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "???? ???? ?? ???? ????")]
        [MinLength(6, ErrorMessage = "???? ???? ???? ????? ?? 5 ?????? ????")]
        public string Password { get; set; }
        public void OnGet()
        {

        }
        public IActionResult Onpost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var user = _userService.LoginUser(new UserLoginDto()
            {
                UserName= UserName,
                PassWord = Password
            });
            if (user ==null)
            {
                ModelState.AddModelError("UserName", "???? ???");
                return Page();
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Test","Test"),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(identity);
            //var properties = new AuthenticationProperties()
            //{
            //    IsPersistent = true
            //};
            HttpContext.SignInAsync(claimPrincipal/*,properties*/);
            return RedirectToPage("../Index");
           
        }
    }
}
