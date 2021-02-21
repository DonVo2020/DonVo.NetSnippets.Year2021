using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfLinqQuerySnippets._04.JSONProcessing.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
                .HasMany(c => c.Sales)
                .WithOne(s => s.Car)
                .HasForeignKey(s => s.CarId);

            car.HasMany(c => c.PartCars)
                .WithOne(pc => pc.Car)
                .HasForeignKey(pc => pc.CarId);
        }
    }
}
