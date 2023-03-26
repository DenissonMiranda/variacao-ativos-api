namespace VariacaoAtivos.Utility.DTOs
{
    public class ResultsDTO
    {
        public MetaDTO? meta { get; set; }
        public List<long>? timestamp { get; set; }
        public IndicatorsDTO? indicators { get; set; }
    }
}
