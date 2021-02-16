using Dominio;
using Dominio.contrato;
using System.Collections.Generic;
using RepositorioADO;

namespace Aplicacao
{
    public class ProdutoAplicacao
    {
        private readonly IRepositorio<Produto> repositorio;

        public ProdutoAplicacao(IRepositorio<Produto> repo)
        {
            repositorio = repo;
        }

        public void Salvar(Produto produto)
        {
            repositorio.Salvar(produto);
        }

        public void Excluir(Produto produto)
        {
            repositorio.Excluir(produto);
        }

        public IEnumerable<Produto> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public Produto ListarPorId(string id)
        {
            return repositorio.ListarPorId(id);
        }


    }
}
