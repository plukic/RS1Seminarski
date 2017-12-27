using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructionDiary.Migrations
{
    public partial class construction_site_open_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenStatus",
                table: "ConstructionSites",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenStatus",
                table: "ConstructionSites");
        }
    }
}
