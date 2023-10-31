using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Group
    {
        public Group()
        {
            GroupProjects = new HashSet<GroupProject>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? LeaderId { get; set; }

        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
