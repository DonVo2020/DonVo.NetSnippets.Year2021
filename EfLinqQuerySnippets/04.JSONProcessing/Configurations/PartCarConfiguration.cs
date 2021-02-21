using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._04.JSONProcessing.Configurations
{
    public class PartCarConfiguration : IEntityTypeConfiguration<PartCar>
    {
        public void Configure(EntityTypeBuilder<PartCar> partCar)
        {
            partCar
                .HasKey(pc => new { pc.PartId, pc.CarId });
        }
    }
}
