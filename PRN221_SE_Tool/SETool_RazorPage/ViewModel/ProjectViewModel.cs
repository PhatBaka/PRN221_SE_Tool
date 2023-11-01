using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SETool_RazorPage.ViewModel
{
    public class ProjectViewModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
