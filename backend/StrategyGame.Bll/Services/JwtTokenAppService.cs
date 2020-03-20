using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using StrategyGame.Model.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace StrategyGame.Bll.Services
{
    public class JwtTokenAppService
    {
        public static object CreateToken(LoginModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokens.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.User),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, model.User),
            };
            var token = new JwtSecurityToken(
                JwtTokens.Issuer,
                JwtTokens.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );
            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
        }
    }
}
