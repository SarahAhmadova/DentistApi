using MedicApp.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class AppointmentsConfiguration
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {
            builder.Property(e => e.Patient).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.Service).IsRequired();
            builder.Property(e => e.createdAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(e => e.Doctor).WithMany().HasForeignKey(e => e.DoctorId);

            builder.ToTable("Appointments");
        }
    }
}
