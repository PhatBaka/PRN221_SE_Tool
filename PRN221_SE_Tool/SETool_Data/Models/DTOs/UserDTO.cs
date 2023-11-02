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
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
        public string Status { get; set; }
    }
	public class CreateUserDTO : UserDTO
	{
		public int RoleId { get; set; }
	}
    public class UpdateUserDTO : UserDTO
    {
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public int RoleId { get; set; }
    }

    public class GetUserDTO : UserDTO
    {
        public int Id { get; set; }
        public GetRoleDTO Role { get; set; }
        public List<GetTeacherProjectDTO> TeacherProjects { get; set; }
        public GetGroupDTO Group { get; set; }
        public List<GetTaskDTO> Tasks { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? Address { get; set; }
    }
}
