using System;
using BookShop.Models;

namespace BookShop.Repositories.IRepository
{
	public interface ICategoryRepository: IRepository<Category>
	{
		void Update(Category obj);

		void Save();
	}
}

