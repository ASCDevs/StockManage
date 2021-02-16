using RepositorioADO;

namespace Aplicacao
{
    public class ClienteAplicacaoConstrutor
    {
        public static ClienteAplicacao ClienteAplicacaoADO()
        {
            return new ClienteAplicacao(new ClienteRepositorioADO());
        }

        
    }
}
