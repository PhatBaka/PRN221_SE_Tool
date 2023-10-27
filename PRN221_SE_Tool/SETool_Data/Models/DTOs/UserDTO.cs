using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Models.DTOs
{
	public class UserDTO
	{
		public string lastName { get; set; }
		public string firstName { get; set; }
		public string email { get; set; }
		public string password { get; set; }
	}
	public class CreateUserDTO : UserDTO
	{
		public string role { get; set; }
	}
	public class GetUserDTO : UserDTO
	{
		public int id { get; set; }
		public int roleId { get; set; }
		public string description { get; set; }
		public string phoneNumber { get; set; }
		public string image { get; set; }
		public string gender { get; set; }
		public string dateOfBirth { get; set; }
		public string city { get; set; }
		public string district { get; set; }
		public string address { get; set; }
		public string status { get; set; }
		public GetGroupDTO? group { get; set; }
		public string? isLeader { get; set; }
	}
	public class UpdateUserDTO : UserDTO
	{
		public string description { get; set; }
		public string phoneNumber { get; set; }
		public IFormFile image { get; set; }
		public string gender { get; set; }
		public string dateOfBirth { get; set; }
		public string city { get; set; }
		public string district { get; set; }
		public string address { get; set; }
		public string status { get; set; }
		public RoleDTO role { get; set; }
	}
}
