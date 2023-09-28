using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    /// <summary>
    /// CORS sert à filtrer les entrés au niveau de l'API
    /// voir comment bien l'utiliser pour sécuriser l'API
    /// ajouter un GUID 
    /// </summary>

    public static class SecurityCROSMethod
    {
        public const string Default_Policy = "DEFAULT_POLICY";
        public const string Policy2 = "Policy2";
        public const string Policy3 = "Policy3";

        // utilisation de configuration à paramétrer
        private static void GetAddCorsOption (this IServiceCollection services , IConfiguration configuration )
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Default_Policy, builder =>
                {
                    // autorisation de tout
                    /*builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();*/
                    // a ajouter par la suite dans un fichier de configuration
                    builder.WithOrigins(configuration["CORS:Orign"]??string.Empty)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                options.AddPolicy(Policy2, builder =>
                {

                    // a ajouter par la suite dans un fichier de configuration
                    builder.WithOrigins("http://127.0.0.1:5501")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                options.AddPolicy(Policy3, builder =>
                {

                    // a ajouter par la suite dans un fichier de configuration
                    builder.WithOrigins("http://127.0.0.1:5502")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        public static void AddCORSSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.GetAddCorsOption(configuration);
        }

        public static void AddCustomAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            string key = configuration["JWT:Key"] ?? throw new InvalidOperationException("La clé Jwt ne doit pas vide."); 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;       // enregistre le token après authentification
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),       // options de l'encodage de la signature key
                    ValidateAudience = false,
                    ValidateActor = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,        // validité du token dans le temps
                };
            });
        } 
    }
}
