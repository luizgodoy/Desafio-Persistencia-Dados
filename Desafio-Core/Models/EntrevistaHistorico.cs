using MongoDB.Bson;

namespace Desafio_Core.Models
{
    public class EntrevistaHistorico
    {
        public ObjectId Id { get; set; }
        public long FuncionarioId { get; set; } 
        public double SalarioAntigo { get; set; }   
        public double SalarioAtual { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}