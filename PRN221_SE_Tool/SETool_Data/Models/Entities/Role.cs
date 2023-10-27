using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
