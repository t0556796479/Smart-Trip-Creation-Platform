using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Model.Migrations
{
    /// <inheritdoc />
    public partial class add_location_to_tripObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "TripObjects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "TripObjects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TripObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "TripObjects");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "TripObjects");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TripObjects");
        }
    }
}
