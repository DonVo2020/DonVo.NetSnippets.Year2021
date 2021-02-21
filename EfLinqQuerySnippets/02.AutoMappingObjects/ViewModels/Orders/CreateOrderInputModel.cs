using System;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._02.AutoMappingObjects.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Customer { get; set; }

        public string ItemName { get; set; }

        public string EmployeeName { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public string Type { get; set; }
    }
}
