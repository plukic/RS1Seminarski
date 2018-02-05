using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class construction_site_user_id_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSites_AspNetUsers_CreatedById",
                table: "ConstructionSites");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSites_CreatedById",
                table: "ConstructionSites");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ConstructionSites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConstructionSites",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_UserId",
                table: "ConstructionSites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSites_AspNetUsers_UserId",
                table: "ConstructionSites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSites_AspNetUsers_UserId",
                table: "ConstructionSites");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSites_UserId",
                table: "ConstructionSites");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ConstructionSites",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ConstructionSites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSites_CreatedById",
                table: "ConstructionSites",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSites_AspNetUsers_CreatedById",
                table: "ConstructionSites",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
