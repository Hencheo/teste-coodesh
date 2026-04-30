using System.Net;
using System.Text.Json;
using SimuladorMicroondas;

namespace Microondas.Api.Middleware
{
    public class TratamentoErrosMiddleware
    {
        private readonly RequestDelegate _proximo;

        public TratamentoErrosMiddleware(RequestDelegate proximo)
        {
            _proximo = proximo;
        }

        public async Task Invoke(HttpContext contexto)
        {
            try
            {
                await _proximo(contexto);
            }
            catch (Exception erro)
            {
                await TratarExcecaoAsync(contexto, erro);
            }
        }

        private static Task TratarExcecaoAsync(HttpContext contexto, Exception erro)
        {
            var codigoStatus = HttpStatusCode.InternalServerError;
            var mensagemErro = "Ocorreu um erro interno no servidor.";

            if (erro is RegraNegocioException)
            {
                codigoStatus = HttpStatusCode.BadRequest;
                mensagemErro = erro.Message;
            }

            // Logar o erro em um arquivo conforme a spec
            LogarErroNoArquivo(erro);

            var resposta = new { mensagem = mensagemErro };
            var jsonResposta = JsonSerializer.Serialize(resposta);

            contexto.Response.ContentType = "application/json";
            contexto.Response.StatusCode = (int)codigoStatus;

            return contexto.Response.WriteAsync(jsonResposta);
        }

        private static void LogarErroNoArquivo(Exception erro)
        {
            try
            {
                var caminhoArquivo = "erros_microondas.log";
                var textoLog = $"\n--- ERRO REGISTRADO EM {DateTime.Now} ---\n" +
                               $"Mensagem: {erro.Message}\n" +
                               $"Inner Exception: {erro.InnerException?.Message}\n" +
                               $"Stack Trace: {erro.StackTrace}\n" +
                               "------------------------------------------\n";

                File.AppendAllText(caminhoArquivo, textoLog);
            }
            catch
            {
                //pra não travar a aplicação se der erro ao logar
            }
        }
    }
}
