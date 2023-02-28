using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookShop.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string ISBN { get; set; }

		[Required]
		public string Author { get; set; }

		[Required]
		[Range(1, 10000)]
		public double Price { get; set; }

		[ValidateNever]
		public string ImageUrl { get; set; }

		[Required]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

		public Book()
		{
		}
	}
}

