using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataBase.EntityConfiguration
{
    internal class SelfieEntityConfiguration : IEntityTypeConfiguration<Selfie>
    {
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable(nameof(Selfie));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(100);

            #region correspondance base 
            builder.HasOne(x => x.Wookie)
                .WithMany(x => x.Selfies);
            //.HasForeignKey(x => x.WookieId); // pas obligé de mettre une clé étrangère

            builder.HasOne(x => x.Image)
                .WithMany(b=>b.Selfies);        // une image peut être dans plusieurs selfies
            #endregion
        }
    }
}
