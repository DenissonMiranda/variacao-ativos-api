namespace VariacaoAtivos.Domain.Interfaces.ExternalData
{
    public interface IYahooFinanceExternalData 
    {
        Task<string> GetAtivosYahooFinance(string ativo);
    }
}
