using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Milestone
    {
        public Milestone()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
