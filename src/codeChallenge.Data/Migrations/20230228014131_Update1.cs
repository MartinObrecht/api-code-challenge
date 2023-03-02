using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeChallenge.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "CoordinatesAddress");

            migrationBuilder.DropIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "CoverageArea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Address",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Address",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea",
                column: "PartnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "CoverageArea");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Address");

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageAreaId = table.Column<int>(type: "int", nullable: false),
                    Latitute = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_CoverageArea_CoverageAreaId",
                        column: x => x.CoverageAreaId,
                        principalTable: "CoverageArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoordinatesAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Latitute = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoordinatesAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoordinatesAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea",
                column: "PartnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_CoverageAreaId",
                table: "Coordinates",
                column: "CoverageAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CoordinatesAddress_AddressId",
                table: "CoordinatesAddress",
                column: "AddressId");
        }
    }
}
