using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SETool_Business.Services;
using SETool_RazorPage.ViewModel;
using System.Threading.Tasks;
using System;
using System.Linq;
using SETool_Data.Models.Constants;

namespace SETool_RazorPage.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public LoginModel(IUserService userService
                                , IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }
        public string Message { get; set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminAccount:Email").Value;
            var password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminAccount:Password").Value;

            if (string.Equals(email, LoginViewModel.Email, StringComparison.OrdinalIgnoreCase)
                && password.Equals(LoginViewModel.Password))
            {
                HttpContext.Session.SetString("ROLE", "ADMIN");
                return RedirectToPage("./Admins/Semesters/Index");
            }

            var userDTO = await _userService.GetUserByEmailAndPassword(LoginViewModel.Email, LoginViewModel.Password);
            if (userDTO != null)
            {
                if (userDTO.Role.Name == RoleConstant.STUDENT)
                {
                    HttpContext.Session.SetInt32("ID", userDTO.Id);
                    HttpContext.Session.SetString("ROLE", "STUDENT");
                    return RedirectToPage("./Students/Groups/Index");
                }
                else if (userDTO.Role.Name == RoleConstant.TEACHER)
                {
                    HttpContext.Session.SetInt32("ID", userDTO.Id);
                    HttpContext.Session.SetString("ROLE", "TEACHER");
                    return RedirectToPage("./Teachers/Projects/Index");
                }
            }

            Message = "Login fail";
            return Page();
        }
    }
}
