using Microsoft.IdentityModel.Tokens;

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
        public static void GetAddCorsOption (this IServiceCollection services , IConfiguration configuration )
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

    }
}
