using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class alterclinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters");

            migrationBuilder.RenameTable(
                name: "MedicalCenters",
                newName: "Clinics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "MedicalCenters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters",
                column: "ClinicId");
        }
    }
}
