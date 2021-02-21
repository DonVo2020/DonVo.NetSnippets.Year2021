using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._04.JSONProcessing.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
