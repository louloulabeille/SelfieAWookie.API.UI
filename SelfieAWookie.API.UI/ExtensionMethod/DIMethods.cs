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
        public static IServiceCollection PrepareInjectionData(this IServiceCollection services )
        {
            services.AddScoped<ISelfieDataLayer, SqlServerSelfieDataLayer>();
            services.AddScoped<ISelfieRepository, SelfieRepository>();

            services.AddScoped<IWookieDataLayer, SqlServerWookieDataLayer>();
            services.AddScoped<IWookieRepository, WookieRepository>();

            services.AddScoped<IImageDataLayer, SqlServerImageDataLayer>();


            // mise en place de MediatR -- modèle CQRS dissociation entre la lecture et l'écriture dans la base de données
            // c'est plutot lourd à mettre en place voir la doc de microsoft de quand la même en place
            // https://learn.microsoft.com/fr-fr/azure/architecture/patterns/cqrs qui explique quand le mettre en place
            // installation mettre le package -- ajouter le service 
            // créer 2 répertoires commands et queries par exmple et créer la classe en IRequest<> / IRequestHandler qui l'utilise
            services.AddMediatR(args=>
            {
                args.RegisterServicesFromAssemblies(typeof(Program).Assembly); // va chercher les classes à partir de la racine du programme
            }
            );

            return services;
        }
    }
}
