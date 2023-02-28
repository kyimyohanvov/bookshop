using System;
using BookShop.Models;

namespace BookShop.Repositories.IRepository
{
	public interface IBookRepository: IRepository<Book>
	{
		void Update(Book obj);
	}
}

