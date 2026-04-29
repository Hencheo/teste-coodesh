using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimuladorMicroondas;

namespace Microondas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MicroondasController : ControllerBase
    {
        private static SimuladorMicroondas.Microondas _microondas = new SimuladorMicroondas.Microondas();
        private static GerenciadorPrograma _gerenciador = new GerenciadorPrograma();

        public class RequisicaoComando
        {
            public int Segundos { get; set; }
            public int Potencia { get; set; }
        }

        [HttpPost("iniciar")]
        public IActionResult Iniciar([FromBody] RequisicaoComando requisicao)
        {
            if (_microondas.Configurar(requisicao.Segundos, requisicao.Potencia))
            {
                _microondas.Iniciar();
                return Ok(new { mensagem = "Aquecimento iniciado", tempo = _microondas.Tempo, potencia = _microondas.Potencia });
            }
            return BadRequest(new { mensagem = _microondas.MensagemErro });
        }

        [HttpPost("inicio-rapido")]
        public IActionResult InicioRapido()
        {
            _microondas.Iniciar();
            return Ok(new { mensagem = "Inicio rapido acionado", tempo = _microondas.Tempo, potencia = _microondas.Potencia });
        }

        [HttpPost("pausar-cancelar")]
        public IActionResult PausarCancelar()
        {
            _microondas.Parar();
            return Ok(new { mensagem = "Comando executado", ligado = _microondas.EstaLigado, pausado = _microondas.EstaPausado });
        }

        [HttpGet("status")]
        public IActionResult ObterStatus()
        {
            _microondas.Atualizar();
            return Ok(new { tela = _microondas.Tela, tempo = _microondas.Tempo, ligado = _microondas.EstaLigado, pausado = _microondas.EstaPausado });
        }
    }
}
