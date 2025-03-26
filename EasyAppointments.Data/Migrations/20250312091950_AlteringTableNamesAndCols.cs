using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class AlteringTableNamesAndCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalCenterName",
                table: "MedicalCenters",
                newName: "ClinicName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "MedicalCenters",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "MedicalCenterId",
                table: "MedicalCenters",
                newName: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClinicName",
                table: "MedicalCenters",
                newName: "MedicalCenterName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MedicalCenters",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "MedicalCenters",
                newName: "MedicalCenterId");
        }
    }
}
