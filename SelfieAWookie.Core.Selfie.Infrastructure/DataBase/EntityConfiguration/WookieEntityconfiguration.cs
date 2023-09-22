using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructure.DataBase.EntityConfiguration
{
    public class WookieEntityconfiguration : IEntityTypeConfiguration<Wookie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Wookie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(Wookie));

            builder.Property(x=>x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");

            builder.Property(x => x.Surname).IsRequired()
                .HasMaxLength(155);

        }
    }
}
