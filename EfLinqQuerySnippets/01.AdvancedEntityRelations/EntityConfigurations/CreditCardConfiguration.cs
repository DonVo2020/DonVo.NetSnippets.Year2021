using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.EntityConfigurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> creditCard)
        {
            creditCard
                .HasOne(cc => cc.PaymentMethod)
                .WithOne(pm => pm.CreditCard)
                .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId);
        }
    }
}
