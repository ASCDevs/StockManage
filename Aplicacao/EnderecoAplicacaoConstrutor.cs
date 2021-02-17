using RepositorioADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class EnderecoAplicacaoConstrutor
    {
        public static ProdutoAplicacao ProdutoAplicacaoADO()
        {
            return new ProdutoAplicacao(new ProdutoRepositorioADO());
        }
    }
}
