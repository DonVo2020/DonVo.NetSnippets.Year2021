using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static EfLinqQuerySnippets._04.JSONProcessing.Models.ModelValidator.CustomerValidator;

namespace EfLinqQuerySnippets._04.JSONProcessing.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
