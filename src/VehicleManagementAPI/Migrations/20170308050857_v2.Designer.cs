using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BWMS.Application.VehicleManagement.DataAccess;

namespace BWMS.Application.VehicleManagement.Migrations
{
    [DbContext(typeof(VehicleManagementDBContext))]
    [Migration("20170308050857_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("BWMS.Application.VehicleManagement.Model.Vehicle", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Type");

                    b.HasKey("Name");

                    b.ToTable("Vehicle");
                });
        }
    }
}
