using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAppointments.Migrations
{
    /// <inheritdoc />
    public partial class addingColToAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTP",
                table: "Admins");
        }
    }
}
