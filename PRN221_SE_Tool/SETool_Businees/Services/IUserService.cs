using SETool_Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Business.Services
{
    public interface IUserService
	{
		// CREATE
		public Task CreateUser(CreateUserDTO userDTO);

		// READ
		public Task<IEnumerable<GetUserDTO>> GetUsersByGroupId(int groupId);
		public Task<GetUserDTO> GetUserById(int id);
		public Task<GetUserDTO> GetUserByEmail(string email);
		public Task<GetUserDTO> GetUserByPhone(string phone); 
		public Task<GetUserDTO> GetUserByEmailAndPassword(string email, string password);
		// UPDATE

		// DELETE
	}
}
