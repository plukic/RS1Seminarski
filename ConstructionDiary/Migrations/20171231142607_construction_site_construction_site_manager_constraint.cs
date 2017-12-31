using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class construction_site_construction_site_manager_constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "ConstructionSiteManagers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConstructionSiteSiteManager",
                columns: table => new
                {
                    ConstructionSiteId = table.Column<int>(nullable: false),
                    ConstructionSiteManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionSiteSiteManager", x => new { x.ConstructionSiteId, x.ConstructionSiteManagerId });
                    table.ForeignKey(
                        name: "FK_ConstructionSiteSiteManager_ConstructionSites_ConstructionSiteId",
                        column: x => x.ConstructionSiteId,
                        principalTable: "ConstructionSites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructionSiteSiteManager_ConstructionSiteManagers_ConstructionSiteManagerId",
                        column: x => x.ConstructionSiteManagerId,
                        principalTable: "ConstructionSiteManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteManagers_ContractId",
                table: "ConstructionSiteManagers",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteSiteManager_ConstructionSiteManagerId",
                table: "ConstructionSiteSiteManager",
                column: "ConstructionSiteManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSiteManagers_Contracts_ContractId",
                table: "ConstructionSiteManagers",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSiteManagers_Contracts_ContractId",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropTable(
                name: "ConstructionSiteSiteManager");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSiteManagers_ContractId",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "ConstructionSiteManagers");
        }
    }
}
