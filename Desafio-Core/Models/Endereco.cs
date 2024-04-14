using Dapper.Contrib.Extensions;

namespace Desafio_Core.Models
{
    [Table("\"FIAP\".\"Enderecos\"")]
    public class Endereco
    {
        public long Id { get; set; }
        public long FuncionarioId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}