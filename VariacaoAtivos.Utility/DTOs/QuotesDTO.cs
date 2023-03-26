using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Utility.DTOs
{
    public class QuotesDTO
    {
        public List<string>? close { get; set; }
        public List<string>? high { get; set; }
        public List<string>? low { get; set; }
        public List<string>? open { get; set; }
        public List<string>? volume { get; set; }
    }
}
