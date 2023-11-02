using SETool_Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services
{
    public interface IProjectService
    {
        // CREATE
        public Task CreateGroupProject(CreateGroupProjectDTO groupProjectDTO, GetUserDTO leader);
        public Task CreateProject(CreateProjectDTO projectDTO, GetUserDTO coreTeacher, List<GetUserDTO> sideTeachers);
        // READ
        public Task<GetProjectDTO> GetProjectByName(string name);
        public Task<IEnumerable<GetProjectDTO>> GetAll(string status);
        public Task<IEnumerable<GetProjectDTO>> GetProjectsByCoreTeacherId(int Id);
        // UPDATE
        // DELETE
    }
}
