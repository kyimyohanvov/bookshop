﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;

		public Category()
		{
		}
	}
}

