using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Semester
    {
        public Semester()
        {
            ProjectSemesters = new HashSet<ProjectSemester>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public virtual ICollection<ProjectSemester> ProjectSemesters { get; set; }
    }
}
