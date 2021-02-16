using Dominio;
using Dominio.contrato;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioADO
{
    public class ClienteRepositorioADO : IRepositorio<Cliente>
    {
        private Contexto contexto;

        private void Inserir(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format(" INSERT INTO Cliente VALUES('{0}','{1}')",cliente.cpf,cliente.NomeCliente);

            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Cliente cliente)
        {
            var strQuery = "";
            strQuery += " UPDATE Cliente SET";
            strQuery += string.Format(" cpf = '{0}', ",cliente.cpf);
            strQuery += string.Format(" NomeCliente = '{0}'",cliente.NomeCliente);

            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
         
        public void Excluir(Cliente cliente)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM CLIENTE WHERE cpf = '{0}' ",cliente.cpf);
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Cliente cliente)
        {
            var listaCpfs = ListarTodos().ToList();
            var existeCpf = false;
            foreach(var cli in listaCpfs)
            {
                if(cli.cpf == cliente.cpf)
                {
                    existeCpf = true;
                }
            }
            //Verificar se há um método mais performático
            //para lidar com grande quantidade de dados
            if (existeCpf)
            {
                Alterar(cliente);
            }else
            {
                Inserir(cliente);
            }
        }
        
        public IEnumerable<Cliente> ListarTodos()
        {
            using(contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM CLIENTE ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }
        
        public Cliente ListarPorId(string id)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" SELECT * FROM CLIENTE WHERE cpf = '{0}' ",id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Cliente> TransformaReaderEmListaDeObjeto(MySqlDataReader reader)
        {
            var clientes = new List<Cliente>();
            while (reader.Read())
            {
                var temObjeto = new Cliente()
                {
                    cpf = reader["cpf"].ToString(),
                    NomeCliente = reader["NomeCliente"].ToString()
                };

                clientes.Add(temObjeto);
            }

            reader.Close();
            return clientes;
        }

    }
}
