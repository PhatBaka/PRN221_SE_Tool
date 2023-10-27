using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class ProjectSemester
    {
        public int ProjectId { get; set; }
        public int SemesterId { get; set; }
        public string Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
