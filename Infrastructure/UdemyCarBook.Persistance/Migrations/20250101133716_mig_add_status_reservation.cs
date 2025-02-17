using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_status_reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffLOcationID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DropOffLOcationID",
                table: "Reservations",
                newName: "DropOffLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffLOcationID",
                table: "Reservations",
                newName: "IX_Reservations_DropOffLocationID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations",
                column: "DropOffLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationID",
                table: "Reservations",
                newName: "DropOffLOcationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffLocationID",
                table: "Reservations",
                newName: "IX_Reservations_DropOffLOcationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffLOcationID",
                table: "Reservations",
                column: "DropOffLOcationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
