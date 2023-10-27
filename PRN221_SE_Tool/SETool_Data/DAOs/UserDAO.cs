using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Constants.Enums;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.DTOs.CommonDTOs;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.DAOs
{
	public class UserDAO
	{
		private static UserDAO instance = null;
		private static readonly object instanceLock = new object();

		private UserDAO()
		{
		}

		public static UserDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null) instance = new UserDAO();
					return instance;
				}
			}
		}

		public async Task<User> GetUserByEmailAndPassword(string email, string password)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.FirstOrDefaultAsync(u => email.Equals(u.Email)
															&& password.Equals(u.Password)
															&& u.Status.Equals(Enum.GetNames(typeof(ObjectStatusEnum)).ElementAt(0)));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<List<User>> GetStudentsByGroupID(Guid groupID)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.Where(u => u.GroupId.Equals(groupID)).ToListAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> GetUserByEmail(string email)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.FirstOrDefaultAsync(u => string.Equals(email, u.Email, StringComparison.OrdinalIgnoreCase));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<int> CreateUser(User userDTO)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					context.Set<User>().Add(userDTO);
					return await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
