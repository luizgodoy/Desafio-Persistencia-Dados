using Desafio_Core.Models;

namespace Desafio_Frontend_Mvc.Models
{
    public class FuncionarioDetalhes
    {
        public Funcionario Funcionario { get; set; }
        public List<EntrevistaHistorico> EntrevistaHistorico { get; set; }
    }
}