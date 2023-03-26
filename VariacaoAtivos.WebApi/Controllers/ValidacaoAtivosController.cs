using Microsoft.AspNetCore.Mvc;
using VariacaoAtivos.Application.Interfaces;

namespace VariacaoAtivos.WebApi.Controllers
{
    [Route("api/ativos")]
    public class ValidacaoAtivosController : BaseController
    {
        private readonly IValidacaoAtivosApp _app;

        public ValidacaoAtivosController(IValidacaoAtivosApp app)
        {
            _app = app;
        }


        [HttpGet("getAtivosYahooFinanceRest")]
        public async Task<IActionResult> GetAtivosYahooFinanceRest(string ativo)
        {
            try
            {
                var returnString = await _app.GetAtivosYahooFinanceRest(ativo);

                return Ok(returnString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        [HttpGet("getAtivosYahooFinance")]
        public async Task<IActionResult> GetAtivosYahooFinance(string ativo)
        {
            try
            {
                var returnString = await _app.GetAtivosYahooFinance(ativo);

                return Ok(returnString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("cadastrarAtivosYahooFinance")]
        public async Task<IActionResult> CadastrarAtivosYahooFinance(string ativo)
        {
            try
            {
                await _app.CadastrarAtivosYahooFinance(ativo);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpGet("consultarVariacaoAtivos")]
        public async Task<IActionResult> ConsultarVariacaoAtivos(string ativo)
        {
            try
            {
                var returnString = await _app.ConsultarVariacaoAtivos(ativo);

                return Ok(returnString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
