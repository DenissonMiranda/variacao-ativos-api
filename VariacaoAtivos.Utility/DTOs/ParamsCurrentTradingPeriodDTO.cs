namespace VariacaoAtivos.Utility.DTOs
{
    public class ParamsCurrentTradingPeriodDTO
    {
        public string? timezone { get; set; }
        public long? start { get; set; }
        public long? end { get; set; }
        public long? gmtoffset { get; set; }
    }
}
