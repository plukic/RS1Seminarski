using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class Document_MetaDataFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlEntries_Worksheets_WorksheetId",
                table: "ControlEntries");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Documents",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentDescription",
                table: "Documents",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorksheetId",
                table: "ControlEntries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlEntries_Worksheets_WorksheetId",
                table: "ControlEntries",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlEntries_Worksheets_WorksheetId",
                table: "ControlEntries");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentDescription",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Documents",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "WorksheetId",
                table: "ControlEntries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ControlEntries_Worksheets_WorksheetId",
                table: "ControlEntries",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
