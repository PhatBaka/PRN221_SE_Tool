using AutoMapper.Execution;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_RazorPage.Extensions;
using SETool_RazorPage.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SETool_RazorPage.Pages.Teachers.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ISemesterService _semesterService;
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public IndexModel(IProjectService projectService
                            , IUserService userService
                            , ISemesterService semesterService)
        {
            _projectService = projectService;
            _userService = userService;
            _semesterService = semesterService;
        }

        public int UserId;
        public IList<GetProjectDTO> Projects;
        public string SemesterName;

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Projects = (IList<GetProjectDTO>) await _projectService.GetProjectsByCoreTeacherId(UserId);
            return Page();
        }
    }
}
