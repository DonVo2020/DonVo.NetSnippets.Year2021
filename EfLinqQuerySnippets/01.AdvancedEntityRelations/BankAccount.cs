using System.ComponentModel.DataAnnotations;
using static EfLinqQuerySnippets._01.AdvancedEntityRelations.ModelValidator.BankAccountValidator;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        [Required]
        [MaxLength(BankNameMaxLength)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(SwiftCodeMaxLength)]
        public string SwiftCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
