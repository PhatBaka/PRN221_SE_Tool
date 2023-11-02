using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SETool_Data.Helpers.Logger;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SETool_Data.DAOs
{
    public class ProjectDAO
    {
        private static ProjectDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProjectDAO()
        {
        }

        public static ProjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new ProjectDAO();
                    return instance;
                }
            }
        }

        public async Task<Project> GetProjectByName(string name)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Projects.FirstOrDefaultAsync(p => p.Name == name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Project>> GetAll(string status)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Projects
                                        .Where(p => p.Status == status)
                                        .Include(s => s.Semester)
                                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<Project> GetProjectById(int id)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Projects
                                        .Include(p => p.Semester)
                                        .FirstOrDefaultAsync(s => s.Id == id);
                                        
                }
            }
            catch (Exception ex)
            {
                LoggerService.Logger(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
