using System;
using System.Collections.Generic;

#nullable disable

namespace SETool_Data.Models.Entities
{
    public partial class Approval
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public string Status { get; set; }
        public DateTime? ApprovalTime { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
