using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Utility.DTOs
{
    public class ChartDTO
    {
        public List<ResultsDTO>? result { get; set; }
        public string? error { get; set; }
    }
}
