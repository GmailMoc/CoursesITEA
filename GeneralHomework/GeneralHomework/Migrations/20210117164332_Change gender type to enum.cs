using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralHomework.Migrations
{
    public partial class Changegendertypetoenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderTmp",
                table: "Humans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                @"
                UPDATE Humans
                SET GenderTmp =
                    CASE Gender
                        WHEN 'Undefined' THEN 0
                        WHEN 'Male' THEN 1
                        WHEN 'Female' THEN 2
                        ELSE 0
                    END
                ");

            migrationBuilder.DropColumn(
                name: "Gender", 
                table: "Humans");

            migrationBuilder.RenameColumn(
                name: "GenderTmp",
                table: "Humans",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Humans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 1,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 2,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 3,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 4,
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 5,
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 6,
                column: "Gender",
                value: "Male");
        }
    }
}
