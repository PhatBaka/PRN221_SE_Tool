using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Extensions;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_RazorPage.Extensions;
using SETool_RazorPage.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SETool_RazorPage.Pages.Students.Projects
{
    public class IndexModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;

        public IndexModel(IProjectService projectService
                            , IGroupService groupService
                            , IUserService userService)
        {
            _projectService = projectService;
            _userService = userService;
            _groupService = groupService;
        }

        public int UserId { get; set; }
        public List<TeacherProjectViewModel> AvailableProjects { get; set; }
        public IList<GetProjectDTO> Projects { get; set; }
        public IList<GetTeacherProjectDTO> TeacherProjects { get; set; }
        public IList<GetGroupProjectDTO> GroupProjects { get; set; }

        public async Task<IActionResult> OnGetProject(int projectId)
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            //RegisterProjects = SessionExtension.GetObjectFromJson<List<GetGroupProjectDTO>>(HttpContext.Session, "REGISTERPROJECT");
            //if (RegisterProjects == null)
            //{

            //}
            var groupID = await _groupService.GetGroupByUserId(UserId);
            CreateGroupProjectDTO createGroupProject = new()
            {
                GroupId = groupID.Id,
                ProjectId = projectId,
                RegisterDate = DateTimePicker.GetDateTimeByTimeZone(),
                Status = "WAITING FOR APPROVE"
            };
            await _projectService.CreateGroupProject(createGroupProject, UserId);
            
            return Page();
        }

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Projects = (IList<GetProjectDTO>)await _projectService.GetAll(ProjectConstant.OPEN_FOR_REGISTER);

            return Page();
        }
    }
}
