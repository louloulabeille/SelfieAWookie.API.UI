using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase.EntityConfiguration;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataBase
{
    public class SelfieDbContext : DbContext , IUnitOfWork
    {
        public SelfieDbContext(DbContextOptions<SelfieDbContext> options) : base(options)
        {
        }


        #region DbSet
        public virtual DbSet<Selfie> Selfies { get; set; }
        public virtual DbSet<Wookie> Wookies { get; set; }
        #endregion

        #region protected Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Selfie>(new SelfieEntityconfiguration());
            modelBuilder.ApplyConfiguration<Wookie>(new WookieEntityconfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*var connection = @"Server=localhost;Database=Selfie-Dev;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connection);*/
        }


        #endregion
    }
}
