using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class WorksheetAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConstructionSiteId",
                table: "Worksheets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Worksheets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Worksheets_ConstructionSiteId",
                table: "Worksheets",
                column: "ConstructionSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_ConstructionSites_ConstructionSiteId",
                table: "Worksheets",
                column: "ConstructionSiteId",
                principalTable: "ConstructionSites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_ConstructionSites_ConstructionSiteId",
                table: "Worksheets");

            migrationBuilder.DropIndex(
                name: "IX_Worksheets_ConstructionSiteId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "ConstructionSiteId",
                table: "Worksheets");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Worksheets");
        }
    }
}
