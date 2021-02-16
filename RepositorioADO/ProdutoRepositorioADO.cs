using Dominio;
using Dominio.contrato;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositorioADO
{
    public class ProdutoRepositorioADO : IRepositorio<Produto>
    {
        private Contexto contexto;

        private void Inserir(Produto produto)
        {
            var strQuery = "";
            strQuery += " INSERT INTO PRODUTO(NomeProduto,CategoriaProduto,Quantidade,Preco) ";
            string precoProduto = Regex.Replace(Convert.ToString(produto.Preco), @"\,", ".");
            strQuery += string.Format(" VALUES ('{0}','{1}',{2},{3}); ",
                produto.NomeProduto, produto.CategoriaProduto, produto.Quantidade, precoProduto
            );

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Produto produto)
        {
            var strQuery = "";
            strQuery += " UPDATE PRODUTO SET";
            strQuery += string.Format(" NomeProduto = '{0}', ", produto.NomeProduto);
            strQuery += string.Format(" CategoriaProduto = '{0}', ", produto.CategoriaProduto);
            strQuery += string.Format(" Quantidade = {0}, ", produto.Quantidade);
            string precoProduto = Regex.Replace(Convert.ToString(produto.Preco),@"\,",".");
            strQuery += string.Format(" Preco = {0} ", precoProduto);
            strQuery += string.Format(" WHERE ProdutoId = {0} ",produto.ProdutoId);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId > 0)
            {
                Alterar(produto);
            }else
            {
                Inserir(produto);
            }
        }

        public void Excluir(Produto produto)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM PRODUTO WHERE ProdutoId = {0} ", produto.ProdutoId);
                contexto.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Produto> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM PRODUTO ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Produto ListarPorId(string id)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM PRODUTO WHERE ProdutoId = {0} ",id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Produto> TransformaReaderEmListaDeObjeto(MySqlDataReader reader)
        {
            var produtos = new List<Produto>();
            while (reader.Read())
            {
                var temObjeto = new Produto()
                {
                    ProdutoId = int.Parse(reader["ProdutoId"].ToString()),
                    NomeProduto = reader["NomeProduto"].ToString(),
                    CategoriaProduto = reader["CategoriaProduto"].ToString(),
                    Quantidade = int.Parse(reader["Quantidade"].ToString()),
                    Preco = double.Parse(reader["Preco"].ToString())
                };

                produtos.Add(temObjeto);
            }
            reader.Close();
            return produtos;
        }
    }
}
