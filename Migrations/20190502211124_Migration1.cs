using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pat_userID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ins_userID",
                table: "Insurance_Companies");

            migrationBuilder.DropColumn(
                name: "dr_password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "dr_userID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "dr_username",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "as_userID",
                table: "Assistants");

            migrationBuilder.AddColumn<string>(
                name: "pat_user_id",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "m_sender_id",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ins_user_id",
                table: "Insurance_Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dr_user_id",
                table: "Doctors",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "as_user_id",
                table: "Assistants",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pat_user_id",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ins_user_id",
                table: "Insurance_Companies");

            migrationBuilder.DropColumn(
                name: "dr_user_id",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "as_user_id",
                table: "Assistants");

            migrationBuilder.AddColumn<int>(
                name: "pat_userID",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "m_sender_id",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ins_userID",
                table: "Insurance_Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "dr_password",
                table: "Doctors",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "dr_userID",
                table: "Doctors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "dr_username",
                table: "Doctors",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "as_userID",
                table: "Assistants",
                nullable: false,
                defaultValue: 0);
        }
    }
}
