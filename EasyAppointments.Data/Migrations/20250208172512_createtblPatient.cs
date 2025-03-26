using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class createtblPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblSpecialities",
                table: "TblSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblProvinces",
                table: "TblProvinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblMedicalCenters",
                table: "TblMedicalCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblDoctors",
                table: "TblDoctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCities",
                table: "TblCities");

            migrationBuilder.RenameTable(
                name: "TblSpecialities",
                newName: "Specialities");

            migrationBuilder.RenameTable(
                name: "TblProvinces",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "TblMedicalCenters",
                newName: "MedicalCenters");

            migrationBuilder.RenameTable(
                name: "TblDoctors",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "TblCities",
                newName: "Cities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialities",
                table: "Specialities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters",
                column: "MedicalCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialities",
                table: "Specialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalCenters",
                table: "MedicalCenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Specialities",
                newName: "TblSpecialities");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "TblProvinces");

            migrationBuilder.RenameTable(
                name: "MedicalCenters",
                newName: "TblMedicalCenters");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "TblDoctors");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "TblCities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblSpecialities",
                table: "TblSpecialities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblProvinces",
                table: "TblProvinces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblMedicalCenters",
                table: "TblMedicalCenters",
                column: "MedicalCenterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblDoctors",
                table: "TblDoctors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCities",
                table: "TblCities",
                column: "Id");
        }
    }
}
