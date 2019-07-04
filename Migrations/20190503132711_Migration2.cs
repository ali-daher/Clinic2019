using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pat_phone",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ins_phone",
                table: "Insurance_Companies");

            migrationBuilder.DropColumn(
                name: "dr_email",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "dr_phone",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "as_phone",
                table: "Assistants");

            migrationBuilder.DropColumn(
                name: "admin_phone",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pat_phone",
                table: "Patients",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ins_phone",
                table: "Insurance_Companies",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dr_email",
                table: "Doctors",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dr_phone",
                table: "Doctors",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "as_phone",
                table: "Assistants",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "admin_phone",
                table: "Admins",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
