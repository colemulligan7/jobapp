using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jobapp.Migrations
{
    public partial class AddPairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key_id = table.Column<int>(type: "int", nullable: false),
                    keyForeignKey = table.Column<int>(type: "int", nullable: false),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    vehicleForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pairs_Key_keyForeignKey",
                        column: x => x.keyForeignKey,
                        principalTable: "Key",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pairs_Vehicle_vehicleForeignKey",
                        column: x => x.vehicleForeignKey,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_keyForeignKey",
                table: "Pairs",
                column: "keyForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_vehicleForeignKey",
                table: "Pairs",
                column: "vehicleForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pairs");
        }
    }
}
