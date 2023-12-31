﻿using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Constants;
using SETool_Data.Models.DTOs;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
					return await context.Users.Include(u => u.Role)
												.Include(u => u.Group)
												.FirstOrDefaultAsync(u => email.Equals(u.Email)
															&& password.Equals(u.Password)
															&& u.Status.Equals(ObjectStatusConstant.ACTIVE));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        public async Task<User> GetUserById(int id)
        {
            try
            {
                using (var context = new SEToolContext())
                {
                    return await context.Users.Include(u => u.Role)
                                                .Include(u => u.Group)
                                                .FirstOrDefaultAsync(u => u.Id == id
                                                            && u.Status.Equals(ObjectStatusConstant.ACTIVE));
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
					return await context.Users.Include(u => u.Role)
												.Include(u => u.Group)
												.FirstOrDefaultAsync(u => email.Equals(u.Email)
															&& u.Status.Equals(ObjectStatusConstant.ACTIVE));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<User> GetUserByPhone(string phone)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.FirstOrDefaultAsync(u => phone.Equals(u.PhoneNumber));
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async System.Threading.Tasks.Task CreateUser(User userDTO)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					context.Set<User>().Add(userDTO);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<User>> GetUsersByGroupId(int groupId)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.Where(u => groupId == u.GroupId).ToListAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<User>> GetUsersNotHaveGroup()
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Users.Where(u => u.GroupId == null).ToListAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
