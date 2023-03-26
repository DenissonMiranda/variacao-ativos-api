using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Utility.DTOs
{
    public class MetaDTO
    {
        public string? currency { get; set; }
        public string? symbol { get; set; }
        public string? exchangeName { get; set; }
        public string? instrumentType { get; set; }
        public long? firstTradeDate { get; set; }
        public long? regularMarketTime { get; set; }
        public long? gmtoffset { get; set; }
        public string? timezone { get; set; }
        public string? exchangeTimezoneName { get; set; }
        public decimal? regularMarketPrice { get; set; }
        public decimal? chartPreviousClose { get; set; }
        public decimal? previousClose { get; set; }
        public decimal? scale { get; set; }
        public decimal? priceHint { get; set; }
        public CurrentTradingPeriodDTO? currentTradingPeriod { get; set; }
        public object? tradingPeriods { get; set; }
        public string? dataGranularity { get; set; }
        public string? range { get; set; }
        public List<string>? validRanges { get; set; }

    }
}
