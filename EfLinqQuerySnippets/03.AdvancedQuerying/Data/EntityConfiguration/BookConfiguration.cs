using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._03.AdvancedQuerying.Data.EntityConfiguration
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.BookId);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.ReleaseDate)
                .IsRequired(false);

            builder.HasOne(e => e.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(e => e.AuthorId);
        }
    }
}
