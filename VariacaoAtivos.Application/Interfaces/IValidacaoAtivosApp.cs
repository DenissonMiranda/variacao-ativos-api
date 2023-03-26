using VariacaoAtivos.Utility.DTOs;

namespace VariacaoAtivos.Application.Interfaces
{
    public interface IValidacaoAtivosApp
    {
        Task<string> GetAtivosYahooFinanceRest(string ativo);
        Task<ResultAtivosYahooFinanceDTO> GetAtivosYahooFinance(string ativo);
        Task<IEnumerable<VariacaoAtivoDTO>> ConsultarVariacaoAtivos(string ativo);
        Task CadastrarAtivosYahooFinance(string ativo);
    }
}
