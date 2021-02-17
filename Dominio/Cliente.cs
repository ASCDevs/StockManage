using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dominio
{
    public class Cliente
    {
        //Adicionar tratamento para ver se já existe aquele CPF Cadastrado
        [DisplayName("CPF")]
        [Remote("verificaCpfUnico", "Cliente", ErrorMessage = "CPF já existente")]
        [Required(ErrorMessage = "Obrigatório o preenchimento do CPF")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Preencha o nome do cliente")]
        [DisplayName("Nome do Cliente")]
        public string NomeCliente { get; set; }
    }
}
