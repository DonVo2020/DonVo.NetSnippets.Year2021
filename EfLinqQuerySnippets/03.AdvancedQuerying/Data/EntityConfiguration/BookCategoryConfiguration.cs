using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._03.AdvancedQuerying.Data.EntityConfiguration
{
    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(e => new { e.BookId, e.CategoryId });

            builder.HasOne(e => e.Category)
                .WithMany(c => c.CategoryBooks)
                .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.Book)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(e => e.BookId);
        }
    }
}
