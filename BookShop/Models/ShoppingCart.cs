﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
	public class ShoppingCart
	{
		public Book Book { get; set; }

		[Range(1, 1000, ErrorMessage="Please enter a value between 1 and 1000")]
		public int Count { get; set; }

		public ShoppingCart()
		{
		}
	}
}

