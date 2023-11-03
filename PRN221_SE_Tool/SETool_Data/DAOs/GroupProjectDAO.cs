using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.DAOs
{
    public class GroupProjectDAO
    {
        private static GroupProjectDAO instance = null;
        private static readonly object instanceLock = new object();

        private GroupProjectDAO()
        {
        }

        public static GroupProjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new GroupProjectDAO();
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<GroupProject>> GetGroupProjectByGroupId(int id)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.GroupProjects
                                        .Include(gp => gp.Project)
                                        .Include(gp => gp.Group)
                                        .Where(gp => gp.GroupId == id)
                                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
