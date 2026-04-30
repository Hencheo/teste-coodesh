using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            // O hash de "admin" gerado pelo nosso Criptografia.GerarHash
            string hashAdmin = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            if (requisicao.Usuario == "admin" && MicroondasWeb.Criptografia.GerarHash(requisicao.Senha) == hashAdmin)
            {
                var claim = new[]
                {
                    new Claim(ClaimTypes.Name, requisicao.Usuario),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var chaveSecreta = Encoding.UTF8.GetBytes("chaveSecretaMicroondas2026@SuperSeguraComMaisDe32Caracteres1234567890");
                var chaveSimetrica = new SymmetricSecurityKey(chaveSecreta);

                var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);

                var configToken = new JwtSecurityToken(
                    claims: claim,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credenciais
                );

                var textoToken = new JwtSecurityTokenHandler().WriteToken(configToken);

                return Ok(new {token = textoToken});
            }
            return Unauthorized(new {mensagem = "Login não autorizado. Confira as credenciais"});
        }
    }
}
