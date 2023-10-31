using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SETool_Data.DAOs
{
    public class GroupDAO
    {
        private static GroupDAO instance = null;
        private static readonly object instanceLock = new object();

        private GroupDAO()
        {
        }

        public static GroupDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new GroupDAO();
                    return instance;
                }
            }
        }

        public async Task<Models.Entities.Group> GetGroupByLeaderId(int leaderId)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Groups.FirstOrDefaultAsync(g => g.LeaderId == leaderId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
