using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class ConstructionSiteManager_DB_Set : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSiteManager_AspNetUsers_UserId1",
                table: "ConstructionSiteManager");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_ConstructionSiteManager_GetConstructionSiteManagerId",
                table: "Worksheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructionSiteManager",
                table: "ConstructionSiteManager");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSiteManager_UserId1",
                table: "ConstructionSiteManager");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConstructionSiteManager");

            migrationBuilder.RenameTable(
                name: "ConstructionSiteManager",
                newName: "ConstructionSiteManagers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConstructionSiteManagers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructionSiteManagers",
                table: "ConstructionSiteManagers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteManagers_UserId",
                table: "ConstructionSiteManagers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSiteManagers_AspNetUsers_UserId",
                table: "ConstructionSiteManagers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_ConstructionSiteManagers_GetConstructionSiteManagerId",
                table: "Worksheets",
                column: "GetConstructionSiteManagerId",
                principalTable: "ConstructionSiteManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSiteManagers_AspNetUsers_UserId",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_Worksheets_ConstructionSiteManagers_GetConstructionSiteManagerId",
                table: "Worksheets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConstructionSiteManagers",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSiteManagers_UserId",
                table: "ConstructionSiteManagers");

            migrationBuilder.RenameTable(
                name: "ConstructionSiteManagers",
                newName: "ConstructionSiteManager");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ConstructionSiteManager",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ConstructionSiteManager",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConstructionSiteManager",
                table: "ConstructionSiteManager",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteManager_UserId1",
                table: "ConstructionSiteManager",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSiteManager_AspNetUsers_UserId1",
                table: "ConstructionSiteManager",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Worksheets_ConstructionSiteManager_GetConstructionSiteManagerId",
                table: "Worksheets",
                column: "GetConstructionSiteManagerId",
                principalTable: "ConstructionSiteManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
