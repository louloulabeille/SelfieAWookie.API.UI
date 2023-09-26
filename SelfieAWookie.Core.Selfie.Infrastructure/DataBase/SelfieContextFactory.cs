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
            IConfigurationBuilder builder = new ConfigurationBuilder();
            //DirectoryInfo? info = Directory.GetParent(Directory.GetCurrentDirectory());

            DbContextOptionsBuilder<SelfieDbContext> optionBuilder = new();
            /*if (info == null)
            {
                optionBuilder.UseSqlServer("Server=localhost;Database=Selfie-Dev;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;"
                , b => b.MigrationsAssembly("SelfieAWookie.API.UI.Migrations"));
            }else
            {
                builder.SetBasePath(Path.Combine(info.FullName, "SelfieAWookie.API.UI"));
                builder.AddJsonFile("appsettings.json");
                IConfigurationRoot configurationRoot = builder.Build();
                //IConfiguration configuration = builder.Build();

                string connexion = configurationRoot.GetConnectionString("AuthentificationSelfieContextConnection") ?? string.Empty;
                //string connexion = configuration.GetConnectionString("AuthentificationSelfieContextConnection") ?? throw new InvalidOperationException("authentification not found json settings");
                optionBuilder.UseSqlServer(connexion, b => b.MigrationsAssembly("SelfieAWookie.API.UI.Migrations"));
            }*/
            optionBuilder.UseSqlServer("Server=localhost;Database=Selfie-Dev;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;"
                , b => b.MigrationsAssembly("SelfieAWookie.API.UI.Migrations"));

            return new SelfieDbContext(optionBuilder.Options);
        }
    }
}
