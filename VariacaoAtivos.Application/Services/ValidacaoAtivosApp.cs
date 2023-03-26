using AutoMapper;
using Newtonsoft.Json;
using System.Globalization;
using VariacaoAtivos.Application.Interfaces;
using VariacaoAtivos.Domain.Entity;
using VariacaoAtivos.Domain.Interfaces.ExternalData;
using VariacaoAtivos.Domain.Interfaces.Repository;
using VariacaoAtivos.Utility.DTOs;

namespace VariacaoAtivos.Application.Services
{
    public class ValidacaoAtivosApp : IValidacaoAtivosApp
    {
        private readonly IMapper _mapper;
        private readonly IYahooFinanceExternalData _dadosExternos;
        private readonly IVariacaoAtivosRepository _variacaoAtivosRepository;

        public ValidacaoAtivosApp(IMapper mapper, 
                                  IYahooFinanceExternalData dadosExternos,
                                  IVariacaoAtivosRepository variacaoAtivosRepository)
        {
            _mapper = mapper;
            _dadosExternos = dadosExternos;
            _variacaoAtivosRepository = variacaoAtivosRepository;

        }
        public async Task<string> GetAtivosYahooFinanceRest(string ativo)
        {
            var result = await _dadosExternos.GetAtivosYahooFinance(ativo);

            return result;
        }

        public async Task<ResultAtivosYahooFinanceDTO> GetAtivosYahooFinance(string ativo)
        {
            try
            {

                var result = await GetAtivosYahooFinanceRest(ativo);

                return JsonConvert.DeserializeObject<ResultAtivosYahooFinanceDTO>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CadastrarAtivosYahooFinance(string ativo)
        {
            try
            {
                ResultAtivosYahooFinanceDTO ativos = await GetAtivosYahooFinance(ativo);
                decimal ValorDiaAnterior = 0;
                decimal PrimeiroValor = 0;

                decimal VariacaoDia = 0;
                decimal VariacaoPrimeiraData = 0;

                for (int i = 0; i < 30; i++)
                {
                    List<long> p_timestamp = ativos.chart.result.FirstOrDefault().timestamp;

                    List<string> p_valores = ativos.chart.result.FirstOrDefault().indicators.quote.FirstOrDefault().open;

                    var data = ConvertTimestampEmDateTime(p_timestamp[i]);

                    var valor = ConverterValorAtivo(p_valores[i]);

                    if (i == 0)
                    {
                        PrimeiroValor = valor;
                    }
                    else
                    {
                        ValorDiaAnterior = ConverterValorAtivo(p_valores[i - 1]);

                        VariacaoDia = Math.Round(((ValorDiaAnterior - valor) / valor) * 100, 2);
                        VariacaoPrimeiraData = Math.Round(((PrimeiroValor - valor) / valor) * 100, 2);
                    }

                    var dadosAtivos = new VariacaoAtivoDTO()
                    {
                        Ativo = ativo,
                        Data = data,
                        Dia = i + 1,
                        Valor = valor,
                        VariacaoDia = VariacaoDia,
                        VariacaoPrimeiraData = VariacaoPrimeiraData
                    };

                    await _variacaoAtivosRepository.Incluir(_mapper.Map<VariacaoAtivo>(dadosAtivos));

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<VariacaoAtivoDTO>> ConsultarVariacaoAtivos(string ativo)
        {
            var dados = await _variacaoAtivosRepository.ConsultarVariacaoAtivos(ativo);

            return _mapper.Map<IEnumerable<VariacaoAtivoDTO>>(dados);
        }

        public DateTime ConvertTimestampEmDateTime(long timestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);

            DateTime dateTime = dateTimeOffset.DateTime;

            string formattedDate = dateTime.ToString("dd/MM/yyyy HH:mm:ss");

            DateTime data = DateTime.ParseExact(formattedDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            return data;
        }

        public decimal ConverterValorAtivo(string valor)
        {
            valor = valor.Replace(".", ",");
            decimal valorDecimal = Decimal.Parse(valor);

            decimal valorArredondado = Math.Round(valorDecimal, 2);

            return valorArredondado;
        }

    }
}
