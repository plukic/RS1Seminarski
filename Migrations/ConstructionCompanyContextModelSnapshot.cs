﻿// <auto-generated />
using GradjevinskiDnevnik.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace GradjevinskiDnevnik.Migrations
{
    [DbContext(typeof(ConstructionCompanyContext))]
    partial class ConstructionCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GradjevinskiDnevnik.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.ConstructionSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<int>("ContractId");

                    b.Property<DateTime>("DateFinish");

                    b.Property<DateTime>("DateStart");

                    b.Property<int>("LocationId");

                    b.Property<int>("ManagerId");

                    b.Property<decimal>("ProjectWorth");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ContractId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ManagerId");

                    b.ToTable("ConstructionSites");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("DocumentId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.ControlEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("DocumentId");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int?>("WorksheetId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("WorksheetId");

                    b.ToTable("ControlEntries");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Location");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Remark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("WorksheetId");

                    b.HasKey("Id");

                    b.HasIndex("WorksheetId");

                    b.ToTable("Remarks");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title");

                    b.Property<int?>("WorksheetId");

                    b.HasKey("Id");

                    b.HasIndex("WorksheetId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("Hash");

                    b.Property<string>("LastName");

                    b.Property<string>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorkerTask", b =>
                {
                    b.Property<int>("WorkerId");

                    b.Property<int>("TaskId");

                    b.Property<string>("WorkDescription");

                    b.HasKey("WorkerId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("WorkerTask");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Worksheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("GetConstructionSiteManagerId");

                    b.Property<string>("WeatherConditions");

                    b.HasKey("Id");

                    b.HasIndex("GetConstructionSiteManagerId");

                    b.ToTable("Worksheets");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetMachine", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("MachineId");

                    b.Property<DateTime>("UsageEnd");

                    b.Property<DateTime>("UsageStart");

                    b.HasKey("WorksheetId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("WorksheetMachine");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetMaterial", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("MaterialId");

                    b.Property<double>("Amount");

                    b.HasKey("WorksheetId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("WorksheetMaterial");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetTool", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("ToolId");

                    b.HasKey("WorksheetId", "ToolId");

                    b.HasIndex("ToolId");

                    b.ToTable("WorksheetTool");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.ConstructionSiteManager", b =>
                {
                    b.HasBaseType("GradjevinskiDnevnik.Models.User");

                    b.Property<string>("Email");

                    b.ToTable("ConstructionSiteManager");

                    b.HasDiscriminator().HasValue("ConstructionSiteManager");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Manager", b =>
                {
                    b.HasBaseType("GradjevinskiDnevnik.Models.User");

                    b.Property<string>("Email")
                        .HasColumnName("Manager_Email");

                    b.ToTable("Manager");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Worker", b =>
                {
                    b.HasBaseType("GradjevinskiDnevnik.Models.User");

                    b.Property<string>("TelephoneNumber");

                    b.ToTable("Worker");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.ConstructionSite", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Manager", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Contract", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.ControlEntry", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet")
                        .WithMany("ControlEntries")
                        .HasForeignKey("WorksheetId");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Remark", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet", "Worksheet")
                        .WithMany("Remarks")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Task", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet")
                        .WithMany("Tasks")
                        .HasForeignKey("WorksheetId");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorkerTask", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Task", "Task")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Worker", "Worker")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.Worksheet", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.ConstructionSiteManager", "GetConstructionSiteManager")
                        .WithMany("Worksheets")
                        .HasForeignKey("GetConstructionSiteManagerId");
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetMachine", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Machine", "Machine")
                        .WithMany("WorksheetMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetMachines")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetMaterial", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Material", "Material")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradjevinskiDnevnik.Models.WorksheetTool", b =>
                {
                    b.HasOne("GradjevinskiDnevnik.Models.Tool", "Tool")
                        .WithMany("WorksheetTools")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradjevinskiDnevnik.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetTools")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
