﻿

using Microsoft.EntityFrameworkCore;
using StockManage.Data.Entities;
using System;
using System.Linq;

namespace StockManage.Data
{
    public class StorageContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Storage> Storage { get; set; }
        //public DbSet<OrderStatus> OrderStatus { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
            MockData();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("DEVUSER");
        //}

        private void MockData()
        {
            if(!Category.Any())
            {
                Category.Add(new Category { categ_name = "Roupas", dt_created = DateTime.Now });
                Category.Add(new Category { categ_name = "Casa e Construção", dt_created = DateTime.Now });
                Category.Add(new Category { categ_name = "Eletrodomésticos", dt_created = DateTime.Now });
                Category.Add(new Category { categ_name = "Perfumes", dt_created = DateTime.Now });
                this.SaveChanges();
            }
            else
            {
                var test = 1;
            }
            
        }
    }
}
