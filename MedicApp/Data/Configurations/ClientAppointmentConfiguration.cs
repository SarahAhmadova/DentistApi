using MedicApp.Data.Entities.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class ClientAppointmentConfiguration : IEntityTypeConfiguration<ClientAppointment>
    {
        public void Configure(EntityTypeBuilder<ClientAppointment> builder)
        {
            builder.Property(e => e.Patient).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.Service).IsRequired();
            builder.Property(e => e.createdAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable("ClientAppointment");
        }
    }
}
