using System;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "100000.00")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
