using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static EfLinqQuerySnippets._01.AdvancedEntityRelations.ModelValidator.UserValidator;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(PasswordMaxLength)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();
    }
}
