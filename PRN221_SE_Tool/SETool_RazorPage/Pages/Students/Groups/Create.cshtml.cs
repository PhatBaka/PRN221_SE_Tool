using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SETool_Business.Services;
using SETool_Business.Services.Impls;
using SETool_Data.DAOs;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using SETool_RazorPage.Extensions;
using SETool_RazorPage.ViewModel;

namespace SETool_RazorPage.Pages.Students.Groups
{
    public class CreateModel : PageModel
    {
        private readonly IGroupService _groupService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateModel(IGroupService groupSerivce
                            , IUserService userService)
        {
            _groupService = groupSerivce;
            _userService = userService;
        }

        public List<GetUserDTO> UsersInPending;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public int UserId;
        public string Message { get; set; }
        public GetGroupDTO Group;

        [BindProperty]
        public GroupViewModel GroupViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserId = (int) HttpContext.Session.GetInt32("ID");
            UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");
            if (SearchString != null)
            {
                UsersInPending ??= new List<GetUserDTO>();
                GetUserDTO user = await _userService.GetUserById(Int32.Parse(SearchString));
                // check this user is not exist
                if (user == null)
                {
                    Message = "This student is not existed";
                }
                // check if this id is teacher
                else if (_userService.GetUserById(Int32.Parse(SearchString)).Result.Role.Name == RoleConstant.TEACHER)
                {
                    Message = "This Id is not student";
                }
                // check is your self
                else if (Int32.Parse(SearchString) == UserId)
                {
                    Message = "You can not add your self";
                }
                // check user is in another group
                else if (await _groupService.GetGroupByUserId(user.Id) != null)
                {
                    Message = "This student is in another group";
                }
                else
                {
                    if (UsersInPending != null)
                    {
                        //  Check if user in pending already edded
                        if (UsersInPending.FirstOrDefault(u => u.Id == user.Id) != null)
                            return Page();
                        UsersInPending.Add(user);
                        SessionExtension.SetObjectAsJson(HttpContext.Session, "PENDINUUSER", UsersInPending);
                    }
                }
            }
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");

            UserId = (int)HttpContext.Session.GetInt32("ID");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UsersInPending.Count <= 3 && UsersInPending.Count >= 4)
            {
                Message = "A group can 3-4 members";
                return Page();
            }

            // create group
            CreateGroupDTO groupDTO = new CreateGroupDTO()
            {
                Name = GroupViewModel.Name,
                Description = GroupViewModel.Description,
                LeaderId = UserId,
                Status = GroupConstant.ACTIVE 
            };

            if (UsersInPending != null)
            {
                // check user in another group or not
                UsersInPending ??= new List<GetUserDTO>();
                UsersInPending = SessionExtension.GetObjectFromJson<List<GetUserDTO>>(HttpContext.Session, "PENDINUUSER");
                // Get leader dto
                UsersInPending.Add(await _userService.GetUserById(UserId));
                await _groupService.CreateGroup(groupDTO, UsersInPending);
            }
            
            return RedirectToPage("./Index");
        }
    }
}
