using VariacaoAtivos.Domain.Interfaces.ExternalData;
using VariacaoAtivos.Infra.Data.DataConfig;
using VariacaoAtivos.Utility.Constant;

namespace VariacaoAtivos.Infra.Data.ExternalData
{
    public class YahooFinanceExternalData : IYahooFinanceExternalData
    {
        private readonly HttpClient _client;
        private readonly YahooFinanceApiConfig _config;

        public YahooFinanceExternalData(YahooFinanceApiConfig config)
        {
            _client = new HttpClient();

            _config = config;
        }

        public async Task<string> GetAtivosYahooFinance(string ativo)
        {
            var metodo = ValidacaoAtivoConstant.YahooFinance.Metodo.ConsultarPrecoDeAtivos + ativo;

            var l_Result = await _client.GetAsync(_config.Dominio + metodo);

            var l_response = await l_Result.Content.ReadAsStringAsync();

            return l_response.ToString();
            
        }

    }
}
