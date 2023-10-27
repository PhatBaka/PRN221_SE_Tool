using SETool_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.IRepos
{
	public interface IGenericRepository<T> where T : class
	{
		public  Task<int> Delete(object id);
		public  Task<int> Update(T obj);
		public  Task<int> Insert(T obj);
		public  Task<T> GetById(object id);
		public Task<IEnumerable<T>> GetAll();
	}
}
