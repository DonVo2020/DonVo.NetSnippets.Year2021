using EfLinqQuerySnippets._01.AdvancedEntityRelations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public class BillsPaymentSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionSting = @"Server=DONVO\SQLEXPRESS;Database=AdvancedEntityRelationsDB;Integrated Security=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionSting);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardConfiguration());            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
