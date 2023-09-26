using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataBase
{
    public class SelfieContextFactory : IDesignTimeDbContextFactory<SelfieDbContext>
    {
        public SelfieDbContext CreateDbContext(string[] args)
        {

            // exception System.Reflection.TargetInvocationException au niveau du builder.Build () voir pourquoi après
            /*IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Settings", "appsettings.json"));
            IConfigurationRoot configurationRoot = builder.Build();
            */
            //string connexion = configurationRoot.GetConnectionString("AuthentificationSelfieContextConnection") ?? string.Empty;

            DbContextOptionsBuilder<SelfieDbContext> optionBuilder = new ();
            //optionBuilder.UseSqlServer(connexion);
            optionBuilder.UseSqlServer("Server=localhost;Database=Selfie-Dev;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;"
                , b => b.MigrationsAssembly("SelfieAWookie.API.UI.Migrations"));

            return new SelfieDbContext(optionBuilder.Options);
        }
    }
}
