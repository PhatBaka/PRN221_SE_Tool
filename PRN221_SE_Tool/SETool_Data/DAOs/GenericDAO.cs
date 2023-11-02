using Microsoft.EntityFrameworkCore;
using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.DAOs
{
	public class GenericDAO<T> where T : class
	{
        private static GenericDAO<T> instance = null;
        private static readonly object instanceLock = new object();

        private GenericDAO()
        {
        }

        public static GenericDAO<T> Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new GenericDAO<T>();
                    return instance;
                }
            }
        }

        public async Task<int> Update(T obj)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					context.Set<T>().Attach(obj);
					context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					return await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<int> Insert(T obj)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					context.Set<T>().Add(obj);
					return await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<int> Delete(object id)
		{
			try
			{
				using (var context = new SEToolContext())
				{
					T existing = context.Set<T>().Find(id);
					context.Set<T>().Remove(existing);
					return await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			try
			{
				using (var context = new SEToolContext())
				{
					return await context.Set<T>().ToListAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}

		public async Task<T> GetById(object id)
		{
			using (var context = new SEToolContext())
			{
				return await context.Set<T>().FindAsync(id);
			}
		}
	}
}
