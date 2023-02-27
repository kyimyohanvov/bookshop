using System;
using System.Linq.Expressions;
using BookShop.Data;
using BookShop.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Repositories
{
	public class Repository<T>: IRepository<T> where T:class
	{
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
            _db = db;
            this.dbSet = _db.Set<T>();
		}

        void IRepository<T>.Add(T Entity)
        {
            dbSet.Add(Entity);
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        void IRepository<T>.Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }
    }
}

