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
    public class EnderecoRepositorioADO : IRepositorio<Endereco>
    {
        private Contexto contexto;

        private void Inserir(Endereco endereco)
        {
            var strQuery = "";
            strQuery += " INSERT INTO ENDERECO(cpf,Logradouro,Numero,CEP,Cidade,UF) ";
            strQuery += string.Format("VALUES('{0}','{1}','{2}',{3},'{4}','{5}'); ", endereco.cpf,
                endereco.Logradouro, endereco.Numero, endereco.CEP, endereco.Cidade, endereco.UF
            );

            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }

        }

        private void Alterar(Endereco endereco)
        {
            var strQuery = "";
            strQuery += " UPDATE ENDERECO SET";
            strQuery += string.Format(" cpf = '{0}', ",endereco.cpf);
            strQuery += string.Format(" Logradouro = '{0}', ",endereco.Logradouro);
            strQuery += string.Format(" Numero = '{0}', ", endereco.Numero);
            strQuery += string.Format(" CEP = {0}, ",endereco.CEP);
            strQuery += string.Format(" Cidade = '{0}', ",endereco.Cidade);
            strQuery += string.Format(" UF = '{0}' ",endereco.UF);
            strQuery += string.Format(" WHERE EnderecoId = {0} ",endereco.EnderecoId);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Endereco endereco)
        {
            if (endereco.EnderecoId>0)
            {
                Alterar(endereco);
            }else
            {
                Inserir(endereco);
            }
        }

        public void Excluir(Endereco endereco)
        {
            using(contexto = new Contexto())
            {
                var strQuery = string.Format(" DELETE FROM ENDERECO WHERE EnderecoId = {0} and cpf = '{1}' ",endereco.EnderecoId,endereco.cpf);
            }
        }

        public IEnumerable<Endereco> ListarTodos()
        {
            using(contexto = new Contexto())
            {
                var strQuery = " SELECT * FROM ENDERECO ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Endereco ListarPorId(string id)
        {
            throw new NotImplementedException();
        }

        private List<Endereco> TransformaReaderEmListaDeObjeto(MySqlDataReader reader)
        {
            var enderecos = new List<Endereco>();
            while (reader.Read())
            {
                var temObjeto = new Endereco()
                {
                    cpf = reader["cpf"].ToString(),
                    EnderecoId = int.Parse(reader["EnderecoId"].ToString()),
                    Logradouro = reader["Logradouro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    CEP = int.Parse(reader["CEP"].ToString()),
                    Cidade = reader["Cidade"].ToString()
                };
                enderecos.Add(temObjeto);
            }
            reader.Close();
            return enderecos;
        }

        

        
       
    }
}
