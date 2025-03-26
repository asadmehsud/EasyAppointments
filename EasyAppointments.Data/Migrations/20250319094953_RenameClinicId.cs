using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class RenameClinicId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClinicId",
                table: "Clinics",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clinics",
                newName: "ClinicId");
        }
    }
}
