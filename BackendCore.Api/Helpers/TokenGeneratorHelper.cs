using BackendCore.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendCore.Api.Helpers
{
    public class TokenGeneratorHelper
    {
        public static string CreateToken(Usuario user, IConfiguration config)
        {

            //cabecera del token de token
            var secretId = config["JWT:secretId"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretId));

            var credentials = new SigningCredentials(
                  securityKey, SecurityAlgorithms.HmacSha256
              );

            var tokenHeader = new JwtHeader(credentials);

            //Claims para almacenar información
            var tokenClaims = new[] {
                new Claim("id", user.Id.ToString()),
                new Claim("nombre", user.Name),
                new Claim("apellidos", user.LastName),
                new Claim("perfil", user.Profile)
            };

            //Payload = cuerpo del token
            var tokenPayload = new JwtPayload(
                issuer: config["JWT:issuer"],
                audience: config["JWT:audience"],
                claims: tokenClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24)
             );

            var successfulToken = new JwtSecurityToken(tokenHeader, tokenPayload);

            return new JwtSecurityTokenHandler().WriteToken(successfulToken);

        }
    }
}
