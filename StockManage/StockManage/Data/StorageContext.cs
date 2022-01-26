

using Microsoft.EntityFrameworkCore;
using StockManage.Data.Entities;
using System;
using System.Linq;

namespace StockManage.Data
{
    public class StorageContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<Storage> Storage { get; set; }
        //public DbSet<OrderStatus> OrderStatus { get; set; }
        //public DbSet<OrderProduct> OrderProducts { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
            MockData();
        }

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

            if (!Product.Any())
            {

                Product.Add(new Product
                {
                    id_category = 2,
                    prod_name = "Camiseta",
                    prod_desc = "Camiseta Masculina de algodão estilo polo.",
                    price_buy = (decimal)48.98,
                    price_sell = (decimal)58.98,
                    dt_created = DateTime.Now
                });
                Product.Add(new Product
                {
                    id_category = 2,
                    prod_name = "Vestido",
                    prod_desc = "Vestido estilo Midi Branco de linho ",
                    price_buy = (decimal)88.35,
                    price_sell = (decimal)122.58,
                    dt_created = DateTime.Now
                });
                Product.Add(new Product
                {
                    id_category = 4,
                    prod_name = "Perfume Olympea Legend",
                    prod_desc = "Perfume Paco Rabanne, Feminino, 50ml ",
                    price_buy = (decimal)352.42,
                    price_sell = (decimal)479.90,
                    dt_created = DateTime.Now
                });
                Product.Add(new Product
                {
                    id_category = 4,
                    prod_name = "Perfume Invictus Legend",
                    prod_desc = "Perfume Paco Rabanne, Masculino, 50ml ",
                    price_buy = (decimal)300.75,
                    price_sell = (decimal)449.90,
                    dt_created = DateTime.Now
                });
                this.SaveChanges();
            }
            
        }
    }
}
