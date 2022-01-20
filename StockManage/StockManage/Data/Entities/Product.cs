﻿using System;

namespace StockManage.Data.Entities
{
    public class Product
    {
        public int id_product { get; set; }
        public int id_category { get; set; }
        public string prod_name { get; set; }
        public string prod_desc { get; set; }
        public decimal price_buy { get; set; }
        public decimal pricel_sell { get; set; }
        public DateTime dt_created { get; set; }
    }
}