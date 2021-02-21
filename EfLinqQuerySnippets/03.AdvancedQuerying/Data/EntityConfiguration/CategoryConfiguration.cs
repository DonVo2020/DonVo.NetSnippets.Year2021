using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._03.AdvancedQuerying.Data.EntityConfiguration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
