using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "report_ins_id",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "report_ins_name",
                table: "Reports",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "cons_treatment",
                table: "Consultations",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "cons_symptoms",
                table: "Consultations",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "report_ins_name",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "report_ins_id",
                table: "Reports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "cons_treatment",
                table: "Consultations",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cons_symptoms",
                table: "Consultations",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}
