using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        public DateTime ExpirationDate { get; set; }

        [NotMapped]
        public decimal LimitLeft => this.Limit - this.MoneyOwed;

        public PaymentMethod PaymentMethod { get; set; }
    }
}
