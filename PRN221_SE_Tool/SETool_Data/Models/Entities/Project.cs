using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Project
    {
        public Project()
        {
            GroupProjects = new HashSet<GroupProject>();
            Milestones = new HashSet<Milestone>();
            TeacherProjects = new HashSet<TeacherProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<Milestone> Milestones { get; set; }
        public virtual ICollection<TeacherProject> TeacherProjects { get; set; }
    }
}
