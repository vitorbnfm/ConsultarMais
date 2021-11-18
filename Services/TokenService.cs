using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Consultar.Models;
using Microsoft.IdentityModel.Tokens;

namespace Consultar.Services {
    public static class TokenService {
        public static string CriarToken(Usuario usuario) {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Settings.key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Role, usuario.Tipo)
                })
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}