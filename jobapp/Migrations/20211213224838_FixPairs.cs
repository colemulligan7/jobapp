using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobapp.Migrations
{
    public partial class FixPairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Key_keyForeignKey",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Vehicle_vehicleForeignKey",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_keyForeignKey",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_vehicleForeignKey",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "keyForeignKey",
                table: "Pairs");

            migrationBuilder.DropColumn(
                name: "vehicleForeignKey",
                table: "Pairs");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs",
                column: "key_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs",
                column: "vehicle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Key_key_id",
                table: "Pairs",
                column: "key_id",
                principalTable: "Key",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Vehicle_vehicle_id",
                table: "Pairs",
                column: "vehicle_id",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Key_key_id",
                table: "Pairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Pairs_Vehicle_vehicle_id",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_key_id",
                table: "Pairs");

            migrationBuilder.DropIndex(
                name: "IX_Pairs_vehicle_id",
                table: "Pairs");

            migrationBuilder.AddColumn<int>(
                name: "keyForeignKey",
                table: "Pairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "vehicleForeignKey",
                table: "Pairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_keyForeignKey",
                table: "Pairs",
                column: "keyForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_vehicleForeignKey",
                table: "Pairs",
                column: "vehicleForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Key_keyForeignKey",
                table: "Pairs",
                column: "keyForeignKey",
                principalTable: "Key",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pairs_Vehicle_vehicleForeignKey",
                table: "Pairs",
                column: "vehicleForeignKey",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
