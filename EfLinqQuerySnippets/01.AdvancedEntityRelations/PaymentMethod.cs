using EfLinqQuerySnippets._01.AdvancedEntityRelations.Attributes;
using EfLinqQuerySnippets._01.AdvancedEntityRelations.Enums;
using System.ComponentModel.DataAnnotations;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        [XorAttribute(nameof(BankAccountId))]
        public int? BankAccountId { get; set; }

        public BankAccount BankAccount { get; set; }

        [XorAttribute(nameof(CreditCardId))]
        public int? CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}
