using Microsoft.IdentityModel.Tokens;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_TAREO_CAMPO.Services
{
    public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
    {
        public string GenerarToken(Guid id, string email)
        {
            var jwtCfg = configuration.GetSection("Jwt");
            var key    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtCfg["SecretKey"]!));
            var creds  = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,   id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti,   Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64)
            };

            var expiration = int.Parse(jwtCfg["ExpirationMinutes"] ?? "60");

            var token = new JwtSecurityToken(
                issuer:             jwtCfg["Issuer"],
                audience:           jwtCfg["Audience"],
                claims:             claims,
                expires:            DateTime.UtcNow.AddMinutes(expiration),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
