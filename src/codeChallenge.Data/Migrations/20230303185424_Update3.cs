using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeChallenge.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Address");

            migrationBuilder.AlterColumn<long>(
                name: "Document",
                table: "Partner",
                type: "bigint",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Address",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea",
                column: "PartnerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoverageArea_PartnerId",
                table: "CoverageArea");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Partner",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 16);

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
    }
}
