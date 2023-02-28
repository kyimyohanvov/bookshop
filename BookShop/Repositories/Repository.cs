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
            //_db.Books.Include(t => t.Category)
            this.dbSet = _db.Set<T>();
		}

        void IRepository<T>.Add(T Entity)
        {
            dbSet.Add(Entity);
        }
        //includeProp - "Category,Order" to get _db.Books.Include(t => t.Category);
        IEnumerable<T> IRepository<T>.GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if(includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
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

