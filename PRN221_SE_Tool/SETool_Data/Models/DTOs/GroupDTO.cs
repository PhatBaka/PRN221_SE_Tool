using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
	public class GroupDTO
	{
		public string name { get; set; }
	}

	public class CreateGroupDTO : GroupDTO
	{
		
	}

	public class UpdateGroupDTO : GroupDTO
	{
		public string Description { get; set; }
		public string Status { get; set; }
	}

	public class GetGroupDTO : GroupDTO
	{
		public string id { get; set; }
		public string description { get; set; }
		public string status { get; set; }
	}
}
