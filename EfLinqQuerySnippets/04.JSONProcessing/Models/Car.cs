using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static EfLinqQuerySnippets._04.JSONProcessing.Models.ModelValidator.CarValidator;


namespace EfLinqQuerySnippets._04.JSONProcessing.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MakeMaxLength)]
        public string Make { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        public long TravelledDistance { get; set; }


        public ICollection<Sale> Sales { get; set; }

        public ICollection<PartCar> PartCars { get; set; } = new HashSet<PartCar>();
    }
}
