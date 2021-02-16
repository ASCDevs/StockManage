using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class Cliente
    {
        //Adicionar tratamento para ver se já existe aquele CPF Cadastrado
        public string cpf { get; set; }              
        public string NomeCliente { get; set; }
    }
}