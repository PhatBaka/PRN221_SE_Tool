using SETool_Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services
{
    public interface IRoleService
    {
        // CREATE
       
        // READ
        public Task<List<RoleDTO>> GetAllRoles();

        // UPDATE

        // DELETE
    }
}
