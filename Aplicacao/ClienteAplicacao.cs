using Dominio;
using Dominio.contrato;
using RepositorioADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class ClienteAplicacao
    {
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteAplicacao(IRepositorio<Cliente> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Cliente cliente)
        {
            repositorio.Salvar(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            repositorio.Excluir(cliente);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Cliente ListaPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
