using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._04.JSONProcessing.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> supplier)
        {
            supplier
                .HasMany(s => s.Parts)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}
