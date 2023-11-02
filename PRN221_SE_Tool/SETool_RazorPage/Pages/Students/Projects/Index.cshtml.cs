using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SETool_RazorPage.Pages.Students.Projects
{
    public class IndexModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public IndexModel(IProjectService projectService
                            , IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
        }

        public int UserId { get; set; }
        public IList<GetProjectDTO> Projects { get; set; }

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Projects = (IList<GetProjectDTO>)await _projectService.GetAll("IN PENDING");
            return Page();
        }
    }
}
