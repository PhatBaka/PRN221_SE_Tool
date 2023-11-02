using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
	public class RoleDTO
	{ 
		public string Name { get; set; }
	}
	public class CreateRoleDTO
	{

	}
	public class GetRoleDTO : RoleDTO
	{
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
