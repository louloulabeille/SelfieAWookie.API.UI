using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;

namespace SelfieAWookie.API.UI.ExtensionMethod
{
    public static class AddAllDbContext
    {
        public static void AddAllContext(this IServiceCollection service, IConfiguration configuration ) {

            string selfieConnection = configuration.GetConnectionString("AuthentificationSelfieContextConnection") 
                ?? throw new InvalidOperationException("Connection string 'AuthentificationUserContextConnection' not found.");
            string identityConnection = configuration.GetConnectionString("IdentityContext") 
                ?? throw new InvalidOperationException("Connection string 'IdentityContext' not found."); 

            service.AddDbContext<SelfieDbContext>(options => {
                options.UseSqlServer(selfieConnection);
            });

            service.AddDbContext<IdentitySelfieDbContext>(options => {
                options.UseSqlServer(identityConnection);
            });
        }
    }
}
