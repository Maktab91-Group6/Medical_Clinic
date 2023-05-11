using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_Project.Migrations
{
    /// <inheritdoc />
    public partial class doctor_patient_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Turns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Turns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Turns");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Turns");
        }
    }
}
