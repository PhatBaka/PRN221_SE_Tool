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
		private GenericDAO<T> dao = new GenericDAO<T>();

		public async Task<int> Delete(object id) => await dao.Delete(id);

		public async Task<IEnumerable<T>> GetAll() => await dao.GetAll();

		public async Task<T> GetById(object id) => await dao.GetById(id);

		public async Task<int> Insert(T obj) => await dao.Insert(obj);

		public async Task<int> Update(T obj) => await dao.Update(obj);

	}
}
