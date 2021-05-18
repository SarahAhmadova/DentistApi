using MedicApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class SepecialityConfiguration: IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.Property(e => e.name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.createdAt).IsRequired().HasDefaultValueSql("GETDATE()");


            builder.ToTable("Specialities");

        }
    }
    
}
