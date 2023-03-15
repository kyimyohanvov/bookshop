using System;
using BookShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
	public class ApplicationDbContext: IdentityDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Book> Books { get; set; }

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}

