using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSqlite.Migrations
{
    public partial class AddEcologic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ECOCount",
                table: "Developers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ECOSelected",
                table: "Developers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ECOYear",
                table: "Developers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ECOCount",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "ECOSelected",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "ECOYear",
                table: "Developers");
        }
    }
}
