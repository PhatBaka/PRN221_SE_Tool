using SETool_Data.DAOs;
using SETool_Data.Models.Entities;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.Repos
{
    public class UserRepository : IUserRepository
	{
		public System.Threading.Tasks.Task CreateUser(User userDTO) => UserDAO.Instance.CreateUser(userDTO);

		public Task<User> GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);

		public Task<User> GetUserByEmailAndPassowrd(string email, string password) => UserDAO.Instance.GetUserByEmailAndPassword(email, password);

        public Task<User> GetUserByPhone(string phone) => UserDAO.Instance.GetUserByPhone(phone);
    }
}
