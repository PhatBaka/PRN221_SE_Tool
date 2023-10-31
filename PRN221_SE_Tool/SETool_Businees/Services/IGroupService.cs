using SETool_Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services
{
    public interface IGroupService
    {
        // CREATE
        public Task CreateGroup(CreateGroupDTO createGroupDTO, List<GetUserDTO> userDTOs);
        // READ
        public Task<GetGroupDTO> GetGroupByUserId(int userID);
        public Task<GetGroupDTO> GetGroupByLeaderId(int leaderID);
        // UPDATE
        // DELETE
    }
}
