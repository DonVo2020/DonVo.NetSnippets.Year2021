using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static EfLinqQuerySnippets._04.JSONProcessing.Models.ModelValidator.PartValidator;


namespace EfLinqQuerySnippets._04.JSONProcessing.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PartCar> PartCars { get; set; }
    }
}
