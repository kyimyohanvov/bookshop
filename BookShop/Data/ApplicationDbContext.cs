using System;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}

