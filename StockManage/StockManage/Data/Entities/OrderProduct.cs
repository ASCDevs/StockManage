using System;

namespace StockManage.Data.Entities
{
    public class OrderProduct
    {
        public int id_order { get; set; }
        public int id_status { get; set; }
        public DateTime dt_created { get; set; }
        public DateTime dt_finished { get; set; }
        public decimal order_total { get; set; }
        public int order_totalitens { get; set; }
    }
}
