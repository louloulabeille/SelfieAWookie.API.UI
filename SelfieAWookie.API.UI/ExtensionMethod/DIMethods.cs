using SelfieAWookie.Core.Selfies.Application.Repository;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class DIMethods
    {
        /// <summary>
        /// Instention de IserviceCollection pour injecter pour les data
        /// </summary>
        /// <param name="services"></param>
        public static void PrepareInjectionData(this IServiceCollection services )
        {
            services.AddScoped<ISelfieDataLayer, SqlServerSelfieDataLayer>();
            services.AddScoped<ISelfieRepository, SelfieRepository>();

            services.AddScoped<IWookieDataLayer, SqlServerWookieDataLayer>();
            services.AddScoped<IWookieRepository, WookieRepository>();

            services.AddScoped<IImageDataLayer, SqlServerImageDataLayer>();
        }
    }
}
