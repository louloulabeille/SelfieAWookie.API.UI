using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SelfieAWookie.Core.Selfies.Application.Configuration;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    /// <summary>
    /// Class d'instension de méthode pour ajouter les injections des classes pour la récupération 
    /// des paramétrages d'environnement de l'application
    /// </summary>
    public static class AddInjectionAppSetting
    {
        #region Méthode static public
        public static void AddCustonAppSetting(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ElementConfigurationSecret>(configuration.GetSection("JWT"));
            services.Configure<ElementConfigurationSecret>(configuration.GetSection("Cros"));
        }

        #endregion
    }
}
