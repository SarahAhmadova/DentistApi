using MedicApp.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class staffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(e => e.Fullname).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Description).HasMaxLength(500).HasColumnType("text");
            builder.Property(e => e.Phone).HasMaxLength(16);
            builder.Property(e => e.Position).IsRequired();
            builder.Property(e => e.createdAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.HasOne(e => e.speciality).WithMany().HasForeignKey(e => e.SpecId);

            builder.ToTable("Staff");

        }
    }
}
