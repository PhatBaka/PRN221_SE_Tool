using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class TeacherProject
    {
        public int TeacherId { get; set; }
        public int ProjectId { get; set; }
        public bool? IsCoreTeacher { get; set; }
        public string Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual User Teacher { get; set; }
    }
}
