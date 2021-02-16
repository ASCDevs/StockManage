using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioADO
{
    public class Contexto : IDisposable
    {
        private readonly MySqlConnection conexao;

        public Contexto()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["EstoqueConfig"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(String strQuery)
        {
            var cmdComando = new MySqlCommand(strQuery, conexao);
            cmdComando.ExecuteNonQuery();
        }

        public MySqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new MySqlCommand(strQuery, conexao);
            return cmdComando.ExecuteReader();
        }


        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
