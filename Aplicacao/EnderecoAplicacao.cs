using Dominio;
using Dominio.contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class EnderecoAplicacao
    {
        private readonly IRepositorio<Endereco> repositorio;

        public EnderecoAplicacao(IRepositorio<Endereco> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Endereco endereco)
        {
            repositorio.Salvar(endereco);
        }

        public void Excluir(Endereco endereco)
        {
            repositorio.Excluir(endereco);
        }

        public IEnumerable<Endereco> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Endereco ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
