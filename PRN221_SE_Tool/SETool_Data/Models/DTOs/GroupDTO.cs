using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
	public class GroupDTO
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

	public class CreateGroupDTO : GroupDTO
	{
        public int LeaderId { get; set; }
    }

	public class UpdateGroupDTO : GroupDTO
	{
        public int LeaderID { get; set; }
	}

	public class GetGroupDTO : GroupDTO
	{
		public int Id { get; set; }
        public int LeaderId { get; set; }
    }
}
