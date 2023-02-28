using System;
using BookShop.Data;
using BookShop.Models;
using BookShop.Repositories.IRepository;

namespace BookShop.Repositories
{
	public class BookRepository: Repository<Book>, IBookRepository
	{
        private ApplicationDbContext _db;
		public BookRepository(ApplicationDbContext db): base(db)
		{
            _db = db;
		}

        void IBookRepository.Update(Book obj)
        {
            var bookToUpdate = _db.Books.FirstOrDefault(b => b.Id == obj.Id);
            if(bookToUpdate != null)
            {
                bookToUpdate.Title = obj.Title;
                bookToUpdate.Description = obj.Description;
                bookToUpdate.ISBN = obj.ISBN;
                bookToUpdate.Price = obj.Price;
                bookToUpdate.CategoryId = obj.CategoryId;

                if(obj.ImageUrl != null)
                {
                    bookToUpdate.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}

