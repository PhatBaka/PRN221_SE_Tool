using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SETool_Business.Services;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_RazorPage.ViewModel;


namespace SETool_RazorPage.Pages
{
    public class LoginPageModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public LoginPageModel(IUserService userService
                                , IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [BindProperty]
        public LoginViewModel loginViewModel{ get; set; }

        //public SelectList Roles { set; get; }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    var roles = await _roleService.GetAllRoles();

        //    Roles = new SelectList(roles, nameof(loginViewModel.Role.Id), nameof(loginViewModel.Role.Name));
        //    return Page();
        //}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminAccount:Email").Value;
            var password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AdminAccount:Password").Value;

            if (string.Equals(email, loginViewModel.Email, StringComparison.OrdinalIgnoreCase)
                && password.Equals(loginViewModel.Password))
            {
                HttpContext.Session.SetString("ROLE", "ADMIN");
                return RedirectToPage("./Admins/Index");
            }

            var userDTO = await _userService.GetUserByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
            if(userDTO != null)
            {
                if (userDTO.roleId == 2)
                {
                    HttpContext.Session.SetString("ROLE", "TEACHER");
                    HttpContext.Session.SetInt32("ID", userDTO.id);
                    return RedirectToPage("./Teachers/Index");
                }
                else if (userDTO.roleId == 1)
                {
                    HttpContext.Session.SetString("ROLE", "STUDENT");
                    HttpContext.Session.SetInt32("ID", userDTO.id);
                    return RedirectToPage("./Students/Index");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
