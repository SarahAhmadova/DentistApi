using Microsoft.EntityFrameworkCore;
using MedicApp.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicApp.Data.Configurations
{
    public class serviceConfiguration : IEntityTypeConfiguration<Entities.Admin.Medservices>
    {
        public void Configure(EntityTypeBuilder<Entities.Admin.Medservices> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Description).HasMaxLength(500).HasColumnType("text");
            builder.Property(e => e.ImgPath).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Icon).IsRequired();
            builder.Property(e => e.createdAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable("Services");
        }
    }
}
