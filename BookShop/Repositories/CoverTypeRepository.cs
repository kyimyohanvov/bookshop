using System;
using BookShop.Data;
using BookShop.Models;
using BookShop.Repositories.IRepository;

namespace BookShop.Repositories
{
	public class CoverTypeRepository: Repository<CoverType>, ICoverTypeRepository
	{
        private ApplicationDbContext _db;
		public CoverTypeRepository(ApplicationDbContext db): base(db)
		{
            _db = db;
		}

        void ICoverTypeRepository.Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        } 
    }
}

