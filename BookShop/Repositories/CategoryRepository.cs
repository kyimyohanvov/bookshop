using System;
using BookShop.Data;
using BookShop.Models;
using BookShop.Repositories.IRepository;

namespace BookShop.Repositories
{
	public class CategoryRepository: Repository<Category>, ICategoryRepository
	{
        private ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db): base(db)
		{
            _db = db;
		}

        void ICategoryRepository.Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}

