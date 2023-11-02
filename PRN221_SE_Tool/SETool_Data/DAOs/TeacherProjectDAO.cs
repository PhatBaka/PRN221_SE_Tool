using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SETool_Data.DAOs
{
    public class TeacherProjectDAO
    {
        private static TeacherProjectDAO instance = null;
        private static readonly object instanceLock = new object();

        private TeacherProjectDAO()
        {
        }

        public static TeacherProjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new TeacherProjectDAO();
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<TeacherProject>> GetTeacherProjectsByTeacherId(int id)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.TeacherProjects.Where(tp => tp.TeacherId == id).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
