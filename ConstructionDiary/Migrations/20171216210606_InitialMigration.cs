using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: true),
                    Manager_Email = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worksheets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    GetConstructionSiteManagerId = table.Column<int>(nullable: true),
                    WeatherConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worksheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worksheets_Users_GetConstructionSiteManagerId",
                        column: x => x.GetConstructionSiteManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionSites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false),
                    DateFinish = table.Column<DateTime>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    ProjectWorth = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructionSites_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionSites_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionSites_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionSites_Users_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    WorksheetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlEntries_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControlEntries_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Remarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    WorksheetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remarks_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(nullable: true),
                    WorksheetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorksheetMachine",
                columns: table => new
                {
                    WorksheetId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    UsageEnd = table.Column<DateTime>(nullable: false),
                    UsageStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetMachine", x => new { x.WorksheetId, x.MachineId });
                    table.ForeignKey(
                        name: "FK_WorksheetMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetMachine_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksheetMaterial",
                columns: table => new
                {
                    WorksheetId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetMaterial", x => new { x.WorksheetId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_WorksheetMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetMaterial_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksheetTool",
                columns: table => new
                {
                    WorksheetId = table.Column<int>(nullable: false),
                    ToolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetTool", x => new { x.WorksheetId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_WorksheetTool_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksheetTool_Worksheets_WorksheetId",
                        column: x => x.WorksheetId,
                        principalTable: "Worksheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerTask",
                columns: table => new
                {
                    WorkerId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    WorkDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerTask", x => new { x.WorkerId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_WorkerTask_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerTask_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_CityId",
                table: "ConstructionSites",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_ContractId",
                table: "ConstructionSites",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_LocationId",
                table: "ConstructionSites",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_ManagerId",
                table: "ConstructionSites",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_DocumentId",
                table: "Contracts",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlEntries_DocumentId",
                table: "ControlEntries",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlEntries_WorksheetId",
                table: "ControlEntries",
                column: "WorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_WorksheetId",
                table: "Remarks",
                column: "WorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorksheetId",
                table: "Tasks",
                column: "WorksheetId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerTask_TaskId",
                table: "WorkerTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMachine_MachineId",
                table: "WorksheetMachine",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetMaterial_MaterialId",
                table: "WorksheetMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_GetConstructionSiteManagerId",
                table: "Worksheets",
                column: "GetConstructionSiteManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorksheetTool_ToolId",
                table: "WorksheetTool",
                column: "ToolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionSites");

            migrationBuilder.DropTable(
                name: "ControlEntries");

            migrationBuilder.DropTable(
                name: "Remarks");

            migrationBuilder.DropTable(
                name: "WorkerTask");

            migrationBuilder.DropTable(
                name: "WorksheetMachine");

            migrationBuilder.DropTable(
                name: "WorksheetMaterial");

            migrationBuilder.DropTable(
                name: "WorksheetTool");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Worksheets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
