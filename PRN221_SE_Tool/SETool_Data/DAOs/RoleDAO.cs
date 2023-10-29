using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.DAOs
{
    public class RoleDAO
    {
        private static RoleDAO instance = null;
        private static readonly object instanceLock = new object();

        private RoleDAO()
        {
        }

        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new RoleDAO();
                    return instance;
                }
            }
        }
    }
}
