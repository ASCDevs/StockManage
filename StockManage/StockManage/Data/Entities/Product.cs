using System;
using System.ComponentModel.DataAnnotations;

namespace StockManage.Data.Entities
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }
        [Required]
        public int id_category { get; set; }
        public string prod_name { get; set; }
        public string prod_desc { get; set; }
        public decimal price_buy { get; set; }
        public decimal price_sell { get; set; }
        public DateTime dt_created { get; set; }
    }
}
