using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
    public interface ITeacherProjectRepository
    {
        // CREATE
        // READ
        public Task<IEnumerable<TeacherProject>> GetTeacherProjectByTeacherId(int id);
        // UPDATE
        // DELETE
    }
}
