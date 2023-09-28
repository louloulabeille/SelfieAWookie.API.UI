using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class AddAllDbContext
    {
        /// <summary>
        /// Méthode qui ajoute dans les services les connections Dbcontext dans l'application
        /// </summary>
        /// <param name="service">méthod d'extension</param>
        /// <param name="configuration">paramétrage de configuration</param> -- injection par méthode
        /// <exception cref="InvalidOperationException">si la connection string n'est pas trouvé une </exception>
        public static void AddAllContext(this IServiceCollection service, IConfiguration configuration ) {

            // recherche de la chaine de connection
            string selfieConnection = configuration.GetConnectionString("AuthentificationSelfieContextConnection") 
                ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found.");
            string identityConnection = configuration.GetConnectionString("IdentityContext") 
                ?? throw new InvalidOperationException("Connection string 'IdentityContext' not found."); 

            // ajout des services
            service.AddDbContext<SelfieDbContext>(options => {
                options.UseSqlServer(selfieConnection);
            });

            service.AddDbContext<IdentitySelfieDbContext>(options => {
                options.UseSqlServer(identityConnection);
            });
        }
    }
}
