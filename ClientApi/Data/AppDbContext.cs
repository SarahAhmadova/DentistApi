using ClientApi.Data.Entities;
using ClientApi.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<StaffResource> Staff { get; set; }
        public DbSet<ServiceResource> Services { get; set; }
        public DbSet<AppointmentResource> ClientAppointment { get; set; } 
        
    }
}
