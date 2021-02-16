using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dominio
{
    public class Cliente
    {
        //Adicionar tratamento para ver se já existe aquele CPF Cadastrado
        [Required(ErrorMessage = "Obrigatório o preenchimento do CPF")]
        [DisplayName("CPF")]
        [Remote(action: "verificaCpfUnico", controller: "~/WebUI/Controllers/ClienteController", ErrorMessage = "CPF já existente")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Preencha o nome do cliente")]
        [DisplayName("Nome do Cliente")]
        public string NomeCliente { get; set; }
    }
}
