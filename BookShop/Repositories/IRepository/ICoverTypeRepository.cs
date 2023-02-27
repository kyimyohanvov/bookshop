using System;
using BookShop.Models;

namespace BookShop.Repositories.IRepository
{
	public interface ICoverTypeRepository: IRepository<CoverType>
	{
		void Update(CoverType obj);
	}
}

