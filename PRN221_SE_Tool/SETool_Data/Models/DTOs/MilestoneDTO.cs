using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    //public int Id { get; set; }
    //public string Name { get; set; }
    //public string Description { get; set; }
    //public DateTime? StartDate { get; set; }
    //public DateTime? EndDate { get; set; }
    //public string Status { get; set; }
    //public int? ProjectId { get; set; }
    public class MilestoneDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }

    public class CreateMilestoneDTO : MilestoneDTO
    {
        public int? ProjectId { get; set; }
    }

    public class UpdateMilestoneDTO : MilestoneDTO
    {
        public int ProjectId { get; set; }
    }

    public class GetMilestoneDTO : MilestoneDTO
    {
        public int Id { get; set; }
        public GetProjectDTO Project { get; set; }
    }
}
