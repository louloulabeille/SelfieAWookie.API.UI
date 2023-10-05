using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Selfies.Application.Configuration;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace SelfieAWookie.API.UI.Outil
{
    public static class GenerateTokenJWT
    {
        public static string GenerateTokenUserJwt(IdentityUser user, ElementConfigurationSecret secret)
        {
            /*ElementConfigurationSecret secret = new();
            configuration.GetSection("JWT").Bind(secret);*/
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            //string secret = configuration["JWT:Key"] ?? throw new InvalidOperationException("Problem key Jwt");
            var key = Encoding.ASCII.GetBytes(secret.Key);

            // descrition du token
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity( new []
                {
                    new Claim("Id",user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email ?? throw new InvalidOperationException("Problem Jwt user.Email")),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),

                // durée de vie du token -- Attention il faut mettre l'option à vrai
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDecriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }

        
    }
}
