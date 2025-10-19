using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_shift_app.Migrations
{
    /// <inheritdoc />
    public partial class latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "TransportUnits");

            migrationBuilder.AddColumn<int>(
                name: "TransportUnitId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TransportUnitId",
                table: "Jobs",
                column: "TransportUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_TransportUnits_TransportUnitId",
                table: "Jobs",
                column: "TransportUnitId",
                principalTable: "TransportUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_TransportUnits_TransportUnitId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_TransportUnitId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TransportUnitId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "TransportUnits",
                type: "int",
                nullable: true);
        }
    }
}
