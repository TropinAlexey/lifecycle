using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BWMS.WorkshopManagementEventHandler.DataAccess;

namespace BWMS.WorkshopManagementEventHandler.Migrations
{
    [DbContext(typeof(WorkshopManagementDBContext))]
    partial class WorkshopManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("BWMS.WorkshopManagementEventHandler.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BWMS.WorkshopManagementEventHandler.Model.MaintenanceJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("ActualEndTime");

                    b.Property<DateTime?>("ActualStartTime");

                    b.Property<string>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Notes");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Name");

                    b.Property<DateTime>("WorkshopPlanningDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Name");

                    b.ToTable("MaintenanceJob");
                });

            modelBuilder.Entity("BWMS.WorkshopManagementEventHandler.Model.Vehicle", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Type");

                    b.HasKey("Name");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("BWMS.WorkshopManagementEventHandler.Model.MaintenanceJob", b =>
                {
                    b.HasOne("BWMS.WorkshopManagementEventHandler.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("BWMS.WorkshopManagementEventHandler.Model.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("Name");
                });
        }
    }
}
