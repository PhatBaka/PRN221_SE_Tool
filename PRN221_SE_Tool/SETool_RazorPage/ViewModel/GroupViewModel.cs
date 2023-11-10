using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SETool_RazorPage.ViewModel
{
    public class GroupViewModel
    {
        
        
		[Required(ErrorMessage = "Please enter a group name.")]
		[MaxLength(50, ErrorMessage = "Group name must not exceed 255 characters.")]
		[BindProperty]
		public string Name { get; set; }
        [Required]
        [BindProperty]
		[MaxLength(255, ErrorMessage = "Description must not exceed 500 characters.")]
		public string Description { get; set; }


	
	}
}
