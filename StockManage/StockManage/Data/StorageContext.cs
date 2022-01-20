

using Microsoft.EntityFrameworkCore;
using StockManage.Data.Entities;

namespace StockManage.Data
{
    public class StorageContext : DbContext
    {

        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
