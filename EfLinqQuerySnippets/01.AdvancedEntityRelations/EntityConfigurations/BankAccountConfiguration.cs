using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.EntityConfigurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> bankAccount)
        {
            bankAccount
                .Property(ba => ba.SwiftCode)
                .IsUnicode(false);

            bankAccount
                .HasOne(ba => ba.PaymentMethod)
                .WithOne(pm => pm.BankAccount)
                .HasForeignKey<PaymentMethod>(pm => pm.BankAccountId);
        }
    }
}
