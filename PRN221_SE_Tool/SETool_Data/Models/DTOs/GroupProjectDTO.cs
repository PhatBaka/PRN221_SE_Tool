using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
    public class GroupProjectDTO
    {
        public string Status { get; set; }
    }
    public class CreateGroupProjectDTO : GroupProjectDTO
    {
        public int GroupId { get; set; }
        public int ProjectId { get; set; }
        public DateTime RegisterDate { get; set; }
    }
    public class UpdateGroupProjectDTO : GroupProjectDTO
    {
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
    public class GetGroupProjectDTO : GroupProjectDTO
    {
        public GetGroupDTO Group;
        public GetProjectDTO Project;
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
