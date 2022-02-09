using System;
using System.ComponentModel.DataAnnotations;

namespace StockManage.Data.Entities
{
    public class Storage
    {
        [Key]
        public int id_storage { get; set; }
        public int id_product { get; set; }
        public int id_store { get; set; }
        public int prod_qtd { get; set; }
        public int prod_limit { get; set; }
        public DateTime dt_update { get; set; }

        public object validateQtdStorage(int qtd_product)
        {

            if(qtd_product < 0) {
                return new { message = "Quantidade do produto deve ser positiva", isOk = false};
            }
            else if (qtd_product > this.prod_limit) {
                return new { message = $"Quantidade informada é maior que o limite do estoque({this.prod_limit})", isOk = false };
            }
            else
            {
                return new { message = "Quantidade aprovada", isOk = true};
            }
        }

        public object validateLimitStorage(int qtd_limit)
        {
            if(qtd_limit < 0)
            {
                return new { message = "O limite deve ser positivo", isOk = false };
            }else if (qtd_limit < this.prod_qtd)
            {
                return new { message = $"Quantidade do produto({this.prod_qtd}) em estoque é maior que o limite informado." , isOk = false};
            }
            else
            {
                return new { message = "Limite aprovado", isOk = true};
            }
        }
    }
}
