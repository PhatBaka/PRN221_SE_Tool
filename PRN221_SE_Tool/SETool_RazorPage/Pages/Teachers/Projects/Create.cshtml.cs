using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_RazorPage.Extensions;
using SETool_RazorPage.ViewModel;

namespace SETool_RazorPage.Pages.Teachers.Projects
{
    public class CreateModel : PageModel
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly ISemesterService _semesterService;

        public CreateModel(IProjectService projectService
                            , IUserService userService
                            , ISemesterService semesterService)
        {
            _projectService = projectService;
            _userService = userService;
            _semesterService = semesterService;
        }

        [BindProperty]
        public ProjectViewModel ProjectViewModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IList<GetProjectDTO> Projects { get; set; }
        public int UserId { get; private set; }
        public List<GetUserDTO> UsersInPending { get; set; }
        public GetSemesterDTO CurrentSemester { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");
            CurrentSemester = await _semesterService.GetCurrentSemester();
            if (SearchString != null)
            {
                GetUserDTO user = await _userService.GetUserById(Int32.Parse(SearchString));
                // Check user is teacher
                if (user.Role.Name == RoleConstant.TEACHER)
                {
                    UsersInPending ??= new List<GetUserDTO>();
                    //  Check if user in pending already edded
                    if (UsersInPending.FirstOrDefault(u => u.Id == user.Id) != null)
                        return Page();
                    UsersInPending.Add(user);
                    SessionExtension.SetObjectAsJson(HttpContext.Session, "PENDINUUSER", UsersInPending);
                }
                else
                    Message = "This user is not teacher";
            }

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");
            CurrentSemester = await _semesterService.GetCurrentSemester();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // create group
            CreateProjectDTO createProjectDTO = new CreateProjectDTO()
            {
                Name = ProjectViewModel.Name,
                Description = ProjectViewModel.Description,
                Status = ProjectConstant.OPEN_FOR_REGISTER,
                SemesterId = CurrentSemester.Id
            };
            
            UsersInPending ??= new List<GetUserDTO>();
            UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");
            await _projectService.CreateProject(createProjectDTO, await _userService.GetUserById(UserId), UsersInPending);

            return RedirectToPage("./Index");
        }
    }
}
