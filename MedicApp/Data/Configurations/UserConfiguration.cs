using MedicApp.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Fullname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(40);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.Token).IsRequired().HasMaxLength(160);
            builder.Property(e => e.createdAt).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.ToTable("Users");

        }
    }
}
