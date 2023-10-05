using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Selfies.Application.Configuration;
using System.Text;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class JwtConfiguration
    {
        public static void AddCustomAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            ElementConfigurationSecret? secret = new();
            configuration.GetSection("JWT").Bind(secret);
            //string key = configuration["JWT:Key"] ?? throw new InvalidOperationException("La clé Jwt ne doit pas vide."); 
            if (secret is null) throw new InvalidOperationException("La clé Jwt ne doit pas vide.");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;       // enregistre le token après authentification
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),       // options de l'encodage de la signature key
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret.Key)),       // options de l'encodage de la signature key
                    ValidateAudience = false,
                    ValidateActor = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,        // validité du token dans le temps -- option temporaire est 
                };
            });
        }
    }
}
