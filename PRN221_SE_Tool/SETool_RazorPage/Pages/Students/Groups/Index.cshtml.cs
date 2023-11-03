using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.Models.DTOs;
using SETool_RazorPage.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        public IList<MemberViewModel> MemberViewModels = new List<MemberViewModel>();
        
        public bool IsLeader;

        public async Task<IActionResult> OnGet()
        {
            UserId = (int)HttpContext.Session.GetInt32("ID");
            Group = await _groupService.GetGroupByUserId(UserId);
            if (Group != null)
            {   
                if(_groupService.GetGroupByUserId(UserId).Result.LeaderId == UserId)
                {
                    IsLeader = true;
                }
                Members = (IList<GetUserDTO>) await _userService.GetUsersByGroupId(Group.Id);
                foreach (var member in Members)
                {
                    MemberViewModel memberViewModel = new()
                    {
                        Email = member.Email,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        Id = member.Id,
                        IsLeader = (Group.LeaderId == member.Id) ? true : false 
                    };
                    MemberViewModels.Add(memberViewModel);
                }
            }
            return Page();
        }
    }
}
