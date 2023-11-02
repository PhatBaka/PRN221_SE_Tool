using SETool_Data.DAOs;
using SETool_Data.Repositories.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETool_Data.Repositories.Repos
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		public async Task<int> Delete(object id) => await GenericDAO<T>.Instance.Delete(id);

		public async Task<IEnumerable<T>> GetAll() => await GenericDAO<T>.Instance.GetAll();

		public async Task<T> GetById(object id) => await GenericDAO<T>.Instance.GetById(id);

		public async Task<int> Insert(T obj) => await GenericDAO<T>.Instance.Insert(obj);

		public async Task<int> Update(T obj) => await GenericDAO<T>.Instance.Update(obj);

	}
}
