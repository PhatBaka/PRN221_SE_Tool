using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SETool_Business.Services;
using SETool_RazorPage.ViewModel;
using System.Threading.Tasks;
using System;

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
                if (userDTO.roleId == 1)
                {
                    HttpContext.Session.SetInt32("ID", userDTO.id);
                    HttpContext.Session.SetString("ROLE", "TEACHER");
                    return RedirectToPage("./Teachers/Index");
                }
                else if (userDTO.roleId == 2)
                {
                    HttpContext.Session.SetInt32("ID", userDTO.id);
                    HttpContext.Session.SetString("ROLE", "STUDENT");
                    return RedirectToPage("./Students/Groups/Index");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
