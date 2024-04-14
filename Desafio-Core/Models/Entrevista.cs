using Dapper.Contrib.Extensions;

namespace Desafio_Core.Models
{
    [Table("\"FIAP\".\"Entrevistas\"")]
    public class Entrevista
    {
        public long Id { get; set; }
        public long FuncionarioId { get; set; }
        public string Empresa { get; set; }
        public DateTime DataEntrevista {  get; set; }
        public double Salario { get; set; }
        public string Responsavel { get; set; }
    }
}