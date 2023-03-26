using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Utility.DTOs
{
    public class VariacaoAtivoDTO
    {
        public int Id { get; set; }
        public string? Ativo { get; set; }
        public int Dia { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public decimal? VariacaoDia { get; set; }
        public decimal? VariacaoPrimeiraData { get; set; }
    }
}
