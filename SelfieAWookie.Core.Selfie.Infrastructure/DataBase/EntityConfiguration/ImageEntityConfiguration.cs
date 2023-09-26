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
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");
            builder.Property(x=>x.Url).HasMaxLength(255)
                .IsRequired();
        }
    }
}
