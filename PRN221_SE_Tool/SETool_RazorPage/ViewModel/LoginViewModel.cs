using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SETool_Data.Models.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SETool_RazorPage.ViewModel
{
	public class LoginViewModel
	{
		[BindProperty]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is invalid")]
		[Required(ErrorMessage = "Email is required")]
		[MaxLength(50)]
		public string Email { get; set; }
		[BindProperty]
		[Required(ErrorMessage = "Password is required")]
		[MaxLength(50)]
		public string Password { get; set; }
    }
}
