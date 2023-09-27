using Microsoft.IdentityModel.Tokens;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class SecurityCROSMethod
    {
        public const string Default_Policy = "DEFAULT_POLICY";

        public static void GetAddCorsOption (this IServiceCollection services )
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
                    builder.WithOrigins("http://127.0.0.1:5500")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

    }
}
