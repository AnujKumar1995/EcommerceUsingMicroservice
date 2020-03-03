
#region Import Packages
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Application.Helper;
using User.Application.Models;
#endregion

namespace User.Application.Helper
{
    public class TokenManager: JwtAuthentication
    {
        #region Instances
        //static HMACSHA256 hmac = new HMACSHA256();
        //private static string key = Convert.ToBase64String(hmac.Key);
        private static string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        private static string Issuer = "localhost";
        #endregion

        #region Generate Token
        public  string GenerateToken(UserViewModel username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature, secret);

            var claims = new ClaimsIdentity(new Claim[]{
            new Claim("UserRole", username.Role),
            new Claim("Email", username.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            });

            var token = new JwtSecurityToken(Issuer,
                Issuer,
                claims.Claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion

    }
}
