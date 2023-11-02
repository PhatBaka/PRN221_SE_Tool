using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
    public interface IGroupRepository
    {
        // CREATE
        // READ
        public Task<Group> GetGroupByLeaderId(int leaderId);
        // UPDATE
        // DELETE
    }
}
