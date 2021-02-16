using RepositorioADO;

namespace Aplicacao
{
    public class ProdutoAplicacaoConstrutor
    {
        public static ProdutoAplicacao ProdutoAplicacaoADO()
        {
            return new ProdutoAplicacao(new ProdutoRepositorioADO());
        }

    }
}
