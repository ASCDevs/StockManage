namespace StockManage.Data.Entities
{
    public class OrderItem
    {
        public int id_orderitem { get; set; }
        public int id_order { get; set; }
        public int id_product { get; set; }
        public decimal item_total { get; set; }
        public int item_qtd { get; set; }
    }
}
