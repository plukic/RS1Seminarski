﻿// <auto-generated />
using ConstructionDiary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ConstructionDiary.Migrations
{
    [DbContext(typeof(ConstructionCompanyContext))]
    [Migration("20171221224428_construction_site_user_id_change")]
    partial class construction_site_user_id_change
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConstructionDiary.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("ConstructionDiary.Models.ConstructionSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<int>("ContractId");

                    b.Property<DateTime>("DateFinish");

                    b.Property<DateTime>("DateStart");

                    b.Property<int>("LocationId");

                    b.Property<decimal>("ProjectWorth");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ContractId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("ConstructionSites");
                });

            modelBuilder.Entity("ConstructionDiary.Models.ConstructionSiteManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("ConstructionSiteManager");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Contract", b =>
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

            modelBuilder.Entity("ConstructionDiary.Models.ControlEntry", b =>
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

            modelBuilder.Entity("ConstructionDiary.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Location");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Remark", b =>
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

            modelBuilder.Entity("ConstructionDiary.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Task", b =>
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

            modelBuilder.Entity("ConstructionDiary.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("ConstructionDiary.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("JobDescription");

                    b.Property<string>("LastName");

                    b.Property<string>("TelephoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorkerTask", b =>
                {
                    b.Property<int>("WorkerId");

                    b.Property<int>("TaskId");

                    b.Property<string>("WorkDescription");

                    b.HasKey("WorkerId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("WorkerTask");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Worksheet", b =>
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

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetMachine", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("MachineId");

                    b.Property<DateTime>("UsageEnd");

                    b.Property<DateTime>("UsageStart");

                    b.HasKey("WorksheetId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("WorksheetMachine");
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetMaterial", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("MaterialId");

                    b.Property<double>("Amount");

                    b.HasKey("WorksheetId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("WorksheetMaterial");
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetTool", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("ToolId");

                    b.HasKey("WorksheetId", "ToolId");

                    b.HasIndex("ToolId");

                    b.ToTable("WorksheetTool");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ConstructionDiary.Models.ConstructionSite", b =>
                {
                    b.HasOne("ConstructionDiary.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ConstructionDiary.Models.ConstructionSiteManager", b =>
                {
                    b.HasOne("ConstructionDiary.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Contract", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConstructionDiary.Models.ControlEntry", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Worksheet")
                        .WithMany("ControlEntries")
                        .HasForeignKey("WorksheetId");
                });

            modelBuilder.Entity("ConstructionDiary.Models.Remark", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Worksheet", "Worksheet")
                        .WithMany("Remarks")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConstructionDiary.Models.Task", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Worksheet")
                        .WithMany("Tasks")
                        .HasForeignKey("WorksheetId");
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorkerTask", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Task", "Task")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Worker", "Worker")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConstructionDiary.Models.Worksheet", b =>
                {
                    b.HasOne("ConstructionDiary.Models.ConstructionSiteManager", "GetConstructionSiteManager")
                        .WithMany("Worksheets")
                        .HasForeignKey("GetConstructionSiteManagerId");
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetMachine", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Machine", "Machine")
                        .WithMany("WorksheetMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetMachines")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetMaterial", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Material", "Material")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConstructionDiary.Models.WorksheetTool", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Tool", "Tool")
                        .WithMany("WorksheetTools")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetTools")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ConstructionDiary.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ConstructionDiary.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ConstructionDiary.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConstructionDiary.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ConstructionDiary.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
