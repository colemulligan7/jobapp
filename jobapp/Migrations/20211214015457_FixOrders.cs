using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobapp.Migrations
{
    public partial class FixOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs");

            migrationBuilder.RenameColumn(
                name: "vehicle",
                table: "Order",
                newName: "tech");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs",
                column: "key_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs",
                column: "vehicle_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs");

            migrationBuilder.RenameColumn(
                name: "tech",
                table: "Order",
                newName: "vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs",
                column: "key_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs",
                column: "vehicle_id");
        }
    }
}
