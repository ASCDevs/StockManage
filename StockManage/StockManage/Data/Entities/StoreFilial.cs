using System.ComponentModel.DataAnnotations;

namespace StockManage.Data.Entities
{
    public class StoreFilial
    {
        [Key]
        public int id_store { get; set; }
        public string store_name { get; set; }
        public string store_address { get; set; }
        public string store_city { get; set; }
        public string store_district { get; set; }
        public string store_country { get; set; }
    }
}
