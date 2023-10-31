using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SETool_Business.Services.Extensions;
using SETool_Business.Services;
using SETool_Data.Models.DTOs;
using SETool_RazorPage.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SETool_RazorPage.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RegisterModel(IRoleService roleService
                                    , IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; }
        [BindProperty]
        public string SelectedRole { get; set; }

        public List<SelectListItem> RoleList;
        public string EmailExistedMessage { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            await ReloadAllData();
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            GetUserDTO userDTO = null;
            // Load Roles again because using post method, it will lost after reload page
            await ReloadAllData();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check email is existed
            if (await _userService.GetUserByEmail(RegisterViewModel.Email) != null)
            {
                EmailExistedMessage = CreateObjectException.EmailExisted;
                return Page();
            }

            // Create user object
            var entity = new CreateUserDTO
            {
                email = RegisterViewModel.Email,
                password = RegisterViewModel.Password,
                firstName = RegisterViewModel.FirstName,
                lastName = RegisterViewModel.LastName,
                roleID = Int32.Parse(SelectedRole)
            };

            // Create new user and return id
            await _userService.CreateUser(entity);

            // Store in session
            userDTO = await _userService.GetUserByEmail(RegisterViewModel.Email);
            HttpContext.Session.SetInt32("ID", userDTO.id);

            // Redirect
            if (userDTO.roleId == 1)
                return RedirectToPage("/Students/Groups/Index");
            else if (userDTO.roleId == 2)
                return RedirectToPage("/Teachers/Index");
            return Page();
        }

        // Validate Confirm Password = Password
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RegisterViewModel.Password != RegisterViewModel.ConfirmPassword)
            {
                yield return new ValidationResult("The password and confirmation password do not match.", new[] { "ConfirmPassword" });
            }
        }

        private async Task ReloadAllData()
        {
            await GetRoles();
        }

        // Load Roles 
        private async Task GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            RoleList = roles.Select(role => new SelectListItem
            {
                Value = role.Id.ToString(),
                Text = role.Name
            }).ToList();
        }
    }
}

