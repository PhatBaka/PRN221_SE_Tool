using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Models.DTOs;
using SETool_RazorPage.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SETool_RazorPage.Pages.Students.Groups
{
    public class IndexModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;

        public IndexModel(IGroupService groupService
                            , IUserService userService)
        {
            _groupService = groupService;
            _userService = userService;
        }

        public int UserId;
        public GetGroupDTO Group;
        public IList<GetUserDTO> Members;
        
        public bool IsLeader;

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Group = await _groupService.GetGroupByUserId(UserId);
            Members = (IList<GetUserDTO>) await _userService.GetUsersByGroupId(Group.id);
            if (Group != null)
            {
                
                if (_groupService.GetGroupByLeaderId(UserId) != null)
                    IsLeader = true;
            }
            return Page();
        }
    }
}
