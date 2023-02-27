using System;
namespace BookShop.Repositories.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository Category { get; }
		ICoverTypeRepository CoverType { get; }

		void Save();
	}
}

