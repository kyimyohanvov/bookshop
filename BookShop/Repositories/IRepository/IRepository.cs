using System;
using System.Linq.Expressions;

namespace BookShop.Repositories.IRepository
{
	public interface IRepository<T> where T:class
	{
		T GetFirstOrDefault(Expression<Func<T, bool>> filter);
		IEnumerable<T> GetAll();
		void Add(T Entity);
		void Remove(T Entity);
	}
}

