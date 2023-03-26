using System.ComponentModel.DataAnnotations;

namespace VariacaoAtivos.Domain.Entity
{
    public class VariacaoAtivo : EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Ativo { get; set; }
        public int Dia { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public decimal? VariacaoDia { get; set; }
        public decimal? VariacaoPrimeiraData { get; set; }
    }
}
