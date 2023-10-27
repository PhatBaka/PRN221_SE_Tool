using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
	public interface IUserRepository
	{
		//CREATE
		public Task<int> CreateUser(User userDTO);
		//READ
		public Task<User> GetUserByEmail(string email);
		public Task<User> GetUserByEmailAndPassowrd(string email, string password);
		//UPDATE
		
		//DELETE
	}
}
