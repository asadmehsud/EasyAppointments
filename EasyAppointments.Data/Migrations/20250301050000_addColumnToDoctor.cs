using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveStatus",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "Doctors");
        }
    }
}
