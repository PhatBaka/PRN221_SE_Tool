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
        public string description { get; set; }
    }

	public class CreateGroupDTO : GroupDTO
	{
        public int leaderId { get; set; }
    }

	public class UpdateGroupDTO : GroupDTO
	{
        public int leaderId { get; set; }
		public string status { get; set; }
	}

	public class GetGroupDTO : GroupDTO
	{
		public int id { get; set; }
		public string status { get; set; }
        public int leaderId { get; set; }
    }
}
