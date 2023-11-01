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
    public class SemesterDAO
    {
        private static SemesterDAO instance = null;
        private static readonly object instanceLock = new object();

        private SemesterDAO()
        {
        }

        public static SemesterDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new SemesterDAO();
                    return instance;
                }
            }
        }

        public async Task<Semester> GetSemesterByName(string name)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Semesters.FirstOrDefaultAsync(s => s.Name == name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

