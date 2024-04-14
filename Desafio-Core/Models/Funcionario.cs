using Dapper.Contrib.Extensions;

namespace Desafio_Core.Models
{
    [Table("\"FIAP\".\"Funcionarios\"")]
    public class Funcionario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
    }
}