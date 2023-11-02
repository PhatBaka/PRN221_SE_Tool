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
		public System.Threading.Tasks.Task CreateUser(User userDTO);
		//READ
		public Task<User> GetUserById(int id);
		public Task<IEnumerable<User>> GetUserNotHaveGroup();
		public Task<IEnumerable<User>> GetUsersByGroupId(int groupId);
		public Task<User> GetUserByPhone(string phone);
		public Task<User> GetUserByEmail(string email);
		public Task<User> GetUserByEmailAndPassowrd(string email, string password);
        //UPDATE

        //DELETE
    }
}
