using SETool_Business.Models;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.DTOs.CommonDTOs;
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
		public Task<IdDTO> CreateUser(CreateUserDTO userDTO, ThisUserObj currentUser);

		// READ
		public Task<GetUserDTO> GetUserByEmailAndPassword(string email, string password);

		// UPDATE

		// DELETE
	}
}
