using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataBase
{
    public class IdentitySelfieContextFactory : IDesignTimeDbContextFactory<IdentitySelfieDbContext>
    {
        public IdentitySelfieDbContext CreateDbContext(string[] args)
        {
            // exception System.Reflection.TargetInvocationException au niveau du builder.Build () voir pourquoi après
            //IConfigurationBuilder builder = new ConfigurationBuilder();
           // DirectoryInfo? info = Directory.GetParent(Directory.GetCurrentDirectory());

             var optionBuilder = new DbContextOptionsBuilder<IdentitySelfieDbContext>();

            optionBuilder.UseSqlServer("Server=localhost;Database=Identity;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;");

            return new IdentitySelfieDbContext(optionBuilder.Options);
        }
    }
}
