using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BWMS.Application.VehicleManagement.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BWMS.Application.VehicleManagement.DataAccess
{
    public class VehicleManagementDBContext : DbContext
    {
        public VehicleManagementDBContext(DbContextOptions<VehicleManagementDBContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>().HasKey(m => m.Name);
            builder.Entity<Vehicle>().ToTable("Vehicle");
            base.OnModelCreating(builder);
        }

        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }
    }
}
