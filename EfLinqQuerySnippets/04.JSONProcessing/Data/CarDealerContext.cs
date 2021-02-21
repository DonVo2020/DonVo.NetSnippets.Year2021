using EfLinqQuerySnippets._04.JSONProcessing.Configurations;
using EfLinqQuerySnippets._04.JSONProcessing.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLinqQuerySnippets._04.JSONProcessing.Data
{
    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
        {
        }

        public CarDealerContext(DbContextOptions options)
            : base(options)
        {
        }

        

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<PartCar> PartCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new PartCarConfiguration());
            modelBuilder.ApplyConfiguration(new PartConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        }
    }
}
