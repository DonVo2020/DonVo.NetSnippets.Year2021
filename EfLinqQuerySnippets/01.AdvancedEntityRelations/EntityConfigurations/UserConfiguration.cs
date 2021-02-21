using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .Property(u => u.Email)
                .IsUnicode(false);

            user
                .Property(u => u.Password)
                .IsUnicode(false);

            user
                .HasMany(u => u.PaymentMethods)
                .WithOne(pm => pm.User)
                .HasForeignKey(pm => pm.UserId);
        }
    }
}
