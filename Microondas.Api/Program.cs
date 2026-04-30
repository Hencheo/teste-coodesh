using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microondas.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
var chaveSecreta = Encoding.UTF8.GetBytes("chaveSecretaMicroondas2026@SuperSeguraComMaisDe32Caracteres1234567890");

builder.Services.AddAuthentication(opcoes => 
{
    opcoes.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opcoes.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opcoes =>
{
    opcoes.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chaveSecreta)
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
var app = builder.Build();

app.UseMiddleware<TratamentoErrosMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("PermitirTudo");
// app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();


