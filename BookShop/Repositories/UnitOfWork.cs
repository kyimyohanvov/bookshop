using System;
using BookShop.Data;
using BookShop.Repositories.IRepository;

namespace BookShop.Repositories
{
	public class UnitOfWork: IUnitOfWork
	{
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        void IUnitOfWork.Save()
        {
            _db.SaveChanges();
        }
    }
}

