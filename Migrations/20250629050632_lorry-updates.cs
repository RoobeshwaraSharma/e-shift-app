using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_shift_app.Migrations
{
    /// <inheritdoc />
    public partial class lorryupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Capacity",
                table: "Lorries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Lorries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Lorries");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Lorries");
        }
    }
}
