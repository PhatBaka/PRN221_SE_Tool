using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SETool_RazorPage.ViewModel
{
    public class GroupViewModel
    {
        [Required]
        [BindProperty]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [BindProperty]
        [MaxLength(225)]
        public string Description { get; set; }
    }
}
