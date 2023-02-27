using System;
namespace BookShop.Repositories.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }

		void Save();
	}
}

