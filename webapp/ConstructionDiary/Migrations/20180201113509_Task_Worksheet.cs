using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ConstructionDiary.Migrations
{
    public partial class Task_Worksheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Worksheets_WorksheetId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "WorksheetId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Worksheets_WorksheetId",
                table: "Tasks",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Worksheets_WorksheetId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "WorksheetId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Worksheets_WorksheetId",
                table: "Tasks",
                column: "WorksheetId",
                principalTable: "Worksheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
