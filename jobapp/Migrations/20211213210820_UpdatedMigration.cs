using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobapp.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleModel",
                table: "VehicleModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechModel",
                table: "TechModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyModel",
                table: "KeyModel");

            migrationBuilder.RenameTable(
                name: "VehicleModel",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "TechModel",
                newName: "Tech");

            migrationBuilder.RenameTable(
                name: "KeyModel",
                newName: "Key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tech",
                table: "Tech",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Key",
                table: "Key",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tech",
                table: "Tech");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Key",
                table: "Key");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "VehicleModel");

            migrationBuilder.RenameTable(
                name: "Tech",
                newName: "TechModel");

            migrationBuilder.RenameTable(
                name: "Key",
                newName: "KeyModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleModel",
                table: "VehicleModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechModel",
                table: "TechModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyModel",
                table: "KeyModel",
                column: "Id");
        }
    }
}
