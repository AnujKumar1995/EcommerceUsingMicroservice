using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Application.Models;

namespace User.Api.Helper
{
    public class TokenManager
    {
        //static HMACSHA256 hmac = new HMACSHA256();
        //private static string key = Convert.ToBase64String(hmac.Key);
        private static string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        private static string Issuer = "localhost";



        public  static string GenerateToken(UserViewModel username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256, secret);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, username.Role),
            new Claim(JwtRegisteredClaimNames.Email, username.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(Issuer,
                Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
