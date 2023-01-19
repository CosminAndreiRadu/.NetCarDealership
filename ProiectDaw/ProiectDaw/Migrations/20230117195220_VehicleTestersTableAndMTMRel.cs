using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDaw.Migrations
{
    public partial class VehicleTestersTableAndMTMRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QATesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QATesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicleTesters",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    QATesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleTesters", x => new { x.VehicleId, x.QATesterId });
                    table.ForeignKey(
                        name: "FK_vehicleTesters_QATesters_QATesterId",
                        column: x => x.QATesterId,
                        principalTable: "QATesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicleTesters_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicleTesters_QATesterId",
                table: "vehicleTesters",
                column: "QATesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicleTesters");

            migrationBuilder.DropTable(
                name: "QATesters");
        }
    }
}
