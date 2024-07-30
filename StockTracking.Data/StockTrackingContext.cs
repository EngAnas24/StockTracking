using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTracking.Models;

namespace StockTracking.Data
{
    public class StockTrackingContext : DbContext
    {
        public StockTrackingContext(DbContextOptions<StockTrackingContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transactions>()
                .Property(e => e.TransactionType)
                .HasConversion(new EnumToStringConverter<TransactionType>());

                       base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<ProductSuppliers> productSuppliers { get; set; }







    }
}
