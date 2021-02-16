using Aplicacao;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTestes
{
    class Program
    {
        static void Main(string[] args)
        {

            var appCliente = ClienteAplicacaoConstrutor.ClienteAplicacaoADO();
            var cliente01 = new Cliente();

            cliente01.cpf = "105";
            cliente01.NomeCliente = "Albert";

            appCliente.Salvar(cliente01);

            var clientes = appCliente.ListarTodos();

            foreach(var cli in clientes)
            {
                Console.WriteLine("{0} - {1} ",cli.cpf,cli.NomeCliente);
            }

            //TesteBD();
            Console.ReadKey();
        }

        public static void TesteBD()
        {
            var appProduto = ProdutoAplicacaoConstrutor.ProdutoAplicacaoADO();

            //var prod1 = new Produto();
            //prod1.ProdutoId = 5;
            //prod1.NomeProduto = "Processador AMD";
            //prod1.CategoriaProduto = "Acessório";
            //prod1.Quantidade = 16;
            //prod1.Preco = 58.30;
            //appProduto.Salvar(prod1);


            //var prod1 = appProduto.ListarPorId("3");
            //appProduto.Excluir(prod1);


            var produtos = appProduto.ListarTodos();

            foreach (var prod in produtos)
            {
                Console.WriteLine("{0} - {1} - Qtd: {2} - R${3} ", prod.NomeProduto, prod.CategoriaProduto, prod.Quantidade, prod.Preco);
            }
        }
    }
}
