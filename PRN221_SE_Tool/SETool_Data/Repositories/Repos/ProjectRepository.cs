using SETool_Data.DAOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.Repos
{
    public class ProjectRepository : IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAll(string status) => ProjectDAO.Instance.GetAll(status);
        public Task<Project> GetProjectById(int id) => ProjectDAO.Instance.GetProjectById(id);
        public Task<Project> GetProjectByName(string name) => ProjectDAO.Instance.GetProjectByName(name);
    }
}
