using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_shift_app.Migrations
{
    /// <inheritdoc />
    public partial class jobIdTransportUnitrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "TransportUnits",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobId",
                table: "TransportUnits");
        }
    }
}
