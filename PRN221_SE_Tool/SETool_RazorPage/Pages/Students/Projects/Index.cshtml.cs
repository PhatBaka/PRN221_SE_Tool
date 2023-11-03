using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Extensions;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_RazorPage.Extensions;
using SETool_RazorPage.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public List<GroupProjectViewModel> RegisterProjects { get; set; }
        public IList<GetProjectDTO> Projects { get; set; }
        public IList<GetGroupProjectDTO> GroupProjects { get; set; }

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Projects = (IList<GetProjectDTO>)await _projectService.GetAll(ProjectConstant.OPEN_FOR_REGISTER);
            var group = await _groupService.GetGroupByUserId(UserId);
            GroupProjects = (IList<GetGroupProjectDTO>) await _projectService.GetProjectsByGroupId(group.Id);
            //GroupProjects = SessionExtension.GetObjectFromJson<List<GetGroupProjectDTO>>(HttpContext.Session, "GROUPPROJECT");
            //if (Request.Query.ContainsKey("Id")
            //        && Request.Query.ContainsKey("Method"))
            //{
            //    if (Request.Query["Method"] == "Register")
            //    {
            //        string projectId = Request.Query["id"];
                    
            //        CreateGroupProjectDTO createGroupProject = new()
            //        {
            //            GroupId = group.Id,
            //            ProjectId = Int32.Parse(projectId),
            //            RegisterDate = DateTimePicker.GetDateTimeByTimeZone(),
            //            Status = ProjectConstant.PENDING
            //        };
            //        await _projectService.CreateGroupProject(createGroupProject, UserId);
                    
            //        return Page();
            //    }
            //}

            TeacherProjectViewModel viewModel;
            List<string> sideTeacherEmail = new List<string>();
            if (Projects != null
                || Projects.Count != 0)
            {
                foreach (var project in Projects)
                {
                    var coreTeacher = _userService.GetUserById(project.TeacherProjects.FirstOrDefault(c => c.IsCoreTeacher == true).TeacherId);
                    viewModel = new()
                    {
                        Id = project.Id,
                        Description = project.Description,
                        Name = project.Name,
                        Semester = project.Semester.Name,
                        Status = project.Status,
                        CoreTeacher = coreTeacher.Result.Email
                    };
                    AvailableProjects ??= new List<TeacherProjectViewModel>();
                    AvailableProjects.Add(viewModel);
                }
            }
            return Page();
        }
    }
}
