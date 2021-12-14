using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobapp.Migrations
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tech");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vehicle",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Vehicle",
                newName: "vin");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tech",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Tech",
                newName: "first_name");

            migrationBuilder.AddColumn<string>(
                name: "make",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "model",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vehicle",
                table: "Tech",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "make",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "model",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Vehicle",
                table: "Tech");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Vehicle",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "vin",
                table: "Vehicle",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Tech",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Tech",
                newName: "Desc");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Vehicle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tech",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
