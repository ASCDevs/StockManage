using System;
using System.ComponentModel.DataAnnotations;

namespace StockManage.Data.Entities
{
    public class Category
    {
        [Key]
        public int id_category { get; set; }
        public string categ_name { get; set; }
        public DateTime dt_created { get; set; }

    }
}
