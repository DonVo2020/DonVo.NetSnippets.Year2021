using System;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class OrderItem
	{
		public int OrderId { get; set; }

		[Required]
		public Order Order { get; set; }

		public int ItemId { get; set; }

		[Required]
		public Item Item { get; set; }

		[Range(1, int.MaxValue)]
		public int Quantity { get; set; }
	}
}
