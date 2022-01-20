﻿using System;

namespace StockManage.Data.Entities
{
    public class Storage
    {
        public int id_storage { get; set; }
        public int id_product { get; set; }
        public int id_store { get; set; }
        public int prod_qtd { get; set; }
        public int prod_limit { get; set; }
        public DateTime dt_update { get; set; }
    }
}