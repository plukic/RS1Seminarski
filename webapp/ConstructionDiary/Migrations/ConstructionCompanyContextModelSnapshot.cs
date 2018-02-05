﻿// <auto-generated />
using ConstructionDiary.DAL;
using DataLayer.Models;
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
    partial class ConstructionCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("DataLayer.Models.ConstructionSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<int>("ContractId");

                    b.Property<DateTime?>("DateFinish");

                    b.Property<DateTime?>("DateStart")
                        .IsRequired();

                    b.Property<int>("LocationId");

                    b.Property<int>("OpenStatus");

                    b.Property<decimal>("ProjectWorth");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ContractId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("ConstructionSites");
                });

            modelBuilder.Entity("DataLayer.Models.ConstructionSiteManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContractId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("UserId");

                    b.ToTable("ConstructionSiteManagers");
                });

            modelBuilder.Entity("DataLayer.Models.ConstructionSiteSiteManager", b =>
                {
                    b.Property<int>("ConstructionSiteId");

                    b.Property<int>("ConstructionSiteManagerId");

                    b.HasKey("ConstructionSiteId", "ConstructionSiteManagerId");

                    b.HasIndex("ConstructionSiteManagerId");

                    b.ToTable("ConstructionSiteSiteManager");
                });

            modelBuilder.Entity("DataLayer.Models.Contract", b =>
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

            modelBuilder.Entity("DataLayer.Models.ControlEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("DocumentId");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("WorksheetId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("WorksheetId");

                    b.ToTable("ControlEntries");
                });

            modelBuilder.Entity("DataLayer.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("Date");

                    b.Property<string>("DocumentDescription");

                    b.Property<string>("FileName");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("DataLayer.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("PurchaseDate");

                    b.Property<int>("Quantity");

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("DataLayer.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double?>("Latitude")
                        .IsRequired();

                    b.Property<double?>("Longitude")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DataLayer.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("Amount")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("DataLayer.Models.Role", b =>
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

            modelBuilder.Entity("DataLayer.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title");

                    b.Property<int>("WorksheetId");

                    b.HasKey("Id");

                    b.HasIndex("WorksheetId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
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

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<bool>("NeedToChangePassword");

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

            modelBuilder.Entity("DataLayer.Models.Worker", b =>
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

            modelBuilder.Entity("DataLayer.Models.WorkerTask", b =>
                {
                    b.Property<int>("WorkerId");

                    b.Property<int>("TaskId");

                    b.Property<string>("WorkDescription");

                    b.HasKey("WorkerId", "TaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("WorkerTask");
                });

            modelBuilder.Entity("DataLayer.Models.Worksheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConstructionSiteId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("GetConstructionSiteManagerId");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Remarks");

                    b.Property<string>("WeatherConditions");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionSiteId");

                    b.HasIndex("GetConstructionSiteManagerId");

                    b.ToTable("Worksheets");
                });

            modelBuilder.Entity("DataLayer.Models.WorksheetEquipment", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("EquipmentId");

                    b.Property<DateTime>("UsageEnd");

                    b.Property<DateTime>("UsageStart");

                    b.HasKey("WorksheetId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("WorksheetEquipment");
                });

            modelBuilder.Entity("DataLayer.Models.WorksheetMaterial", b =>
                {
                    b.Property<int>("WorksheetId");

                    b.Property<int>("MaterialId");

                    b.Property<double>("Amount");

                    b.HasKey("WorksheetId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("WorksheetMaterial");
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

            modelBuilder.Entity("DataLayer.Models.ConstructionSite", b =>
                {
                    b.HasOne("DataLayer.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataLayer.Models.ConstructionSiteManager", b =>
                {
                    b.HasOne("DataLayer.Models.Contract")
                        .WithMany("SiteManagers")
                        .HasForeignKey("ContractId");

                    b.HasOne("DataLayer.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("DataLayer.Models.ConstructionSiteSiteManager", b =>
                {
                    b.HasOne("DataLayer.Models.ConstructionSite", "ConstructionSite")
                        .WithMany("ConstructionSiteManagers")
                        .HasForeignKey("ConstructionSiteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.ConstructionSiteManager", "ConstructionSiteManager")
                        .WithMany("ConstructionSites")
                        .HasForeignKey("ConstructionSiteManagerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.Contract", b =>
                {
                    b.HasOne("DataLayer.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.ControlEntry", b =>
                {
                    b.HasOne("DataLayer.Models.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Worksheet", "Worksheet")
                        .WithMany("ControlEntries")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.Task", b =>
                {
                    b.HasOne("DataLayer.Models.Worksheet", "Worksheet")
                        .WithMany("Tasks")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.WorkerTask", b =>
                {
                    b.HasOne("DataLayer.Models.Task", "Task")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Worker", "Worker")
                        .WithMany("WorkerTasks")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.Worksheet", b =>
                {
                    b.HasOne("DataLayer.Models.ConstructionSite", "ConstructionSite")
                        .WithMany()
                        .HasForeignKey("ConstructionSiteId");

                    b.HasOne("DataLayer.Models.ConstructionSiteManager", "GetConstructionSiteManager")
                        .WithMany("Worksheets")
                        .HasForeignKey("GetConstructionSiteManagerId");
                });

            modelBuilder.Entity("DataLayer.Models.WorksheetEquipment", b =>
                {
                    b.HasOne("DataLayer.Models.Equipment", "Equipment")
                        .WithMany("WorksheetEquipment")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetEquipment")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Models.WorksheetMaterial", b =>
                {
                    b.HasOne("DataLayer.Models.Material", "Material")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.Worksheet", "Worksheet")
                        .WithMany("WorksheetMaterials")
                        .HasForeignKey("WorksheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("DataLayer.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataLayer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataLayer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("DataLayer.Models.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataLayer.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
