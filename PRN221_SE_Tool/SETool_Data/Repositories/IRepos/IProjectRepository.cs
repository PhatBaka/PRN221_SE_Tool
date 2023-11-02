using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
    public interface IProjectRepository
    {
        // CREATE
        // READ
        public Task<Project> GetProjectByName(string name);
        public Task<Project> GetProjectById(int id);
        public Task<IEnumerable<Project>> GetAll();
        // UPDATE
        // DELETE
    }
}
