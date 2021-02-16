using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Produto
    {

        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o nome do produto")]
        public string NomeProduto { get; set; }

        [Required(ErrorMessage ="Preencha a categoria do produto")]
        public string CategoriaProduto { get; set; }

        [Required(ErrorMessage = "Especifique a quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Preencha o preço")]
        public double Preco { get; set; }

    }
}
