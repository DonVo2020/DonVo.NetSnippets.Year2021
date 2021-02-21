using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects
{
    public class Category
	{
		public int Id { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 3)]
		public string Name { get; set; }

		public ICollection<Item> Items { get; set; }
	}
}
