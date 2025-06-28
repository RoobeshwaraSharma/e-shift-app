using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_shift_app.Migrations
{
    /// <inheritdoc />
    public partial class AddJobStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_TransportUnits_TransportUnitId",
                table: "Loads");

            migrationBuilder.AlterColumn<int>(
                name: "TransportUnitId",
                table: "Loads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_TransportUnits_TransportUnitId",
                table: "Loads",
                column: "TransportUnitId",
                principalTable: "TransportUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loads_TransportUnits_TransportUnitId",
                table: "Loads");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "TransportUnitId",
                table: "Loads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loads_TransportUnits_TransportUnitId",
                table: "Loads",
                column: "TransportUnitId",
                principalTable: "TransportUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
