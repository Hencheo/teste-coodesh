using Microsoft.AspNetCore.Mvc;

namespace Microondas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        public class LoginRequisicao
        {
            public string Usuario { get; set; } = string.Empty;
            public string Senha { get; set; } = string.Empty;
        }

        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequisicao requisicao)
        {
            if (requisicao.Usuario == "admin" && requisicao.Senha == "admin")
            {
                return Ok(new {menssagem = "Login efetuado com sucesso"});
            }
            return Unauthorized(new {menssagem = "Login não autorizado. Confira as credenciais"});
        }
    }
}
