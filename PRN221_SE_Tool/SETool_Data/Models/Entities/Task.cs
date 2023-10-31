using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Task
    {
        public Task()
        {
            Approvals = new HashSet<Approval>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public DateTime? AssignedDate { get; set; }
        public int? AssignedById { get; set; }
        public string Resouce { get; set; }
        public int? MilestoneId { get; set; }
        public int? AssignedToId { get; set; }
        public string Status { get; set; }

        public virtual User AssignedTo { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
    }
}
