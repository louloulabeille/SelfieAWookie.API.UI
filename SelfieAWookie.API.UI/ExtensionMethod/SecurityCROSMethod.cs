using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Selfies.Application.Configuration;
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
        public const string PolicyAll = "PolicyAll";        // ouverture pour tous

        // utilisation de configuration à paramétrer
        private static void GetAddCorsOption (this IServiceCollection services , IConfiguration configuration )
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyAll, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                options.AddPolicy(Default_Policy, builder =>
                {
                    // autorisation de tout
                    /*builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();*/

                    ElementConfigurationCros cros = new ();
                    configuration.GetSection("Cors").Bind(cros);

                    //builder.WithOrigins(configuration["Cors:Orign"] ??string.Empty)
                    builder.WithOrigins(cros.Origin)
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

    }
}
