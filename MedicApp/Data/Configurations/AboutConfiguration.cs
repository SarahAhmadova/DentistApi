using MedicApp.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<aboutus>
    {
        public void Configure(EntityTypeBuilder<aboutus> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(50);
            builder.Property(e => e.textContext).HasMaxLength(500).HasColumnType("text");
            builder.Property(e => e.ImgPath).HasMaxLength(150);

            builder.ToTable("AboutUs");
        }
    }
}
