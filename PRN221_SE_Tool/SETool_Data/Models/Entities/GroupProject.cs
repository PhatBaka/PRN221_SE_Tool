using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class GroupProject
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string Status { get; set; }
        public int? ApprovedBy { get; set; }

        public virtual Group Group { get; set; }
        public virtual Project Project { get; set; }
    }
}
