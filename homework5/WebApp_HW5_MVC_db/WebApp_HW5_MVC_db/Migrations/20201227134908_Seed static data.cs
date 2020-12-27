using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_HW5_MVC_db.Migrations
{
    public partial class Seedstaticdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 1, 317729, "US", 328200000, 16800450, 17860634, false });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 2, 145810, "India", 1353150536, 9606111, 10055560, false });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeadCount", "Name", "Population", "RecoveredCount", "SickCount", "Vaccine" },
                values: new object[] { 3, 186764, "Brazil", 209500000, 6409986, 7238600, false });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CountryId", "Name", "Zone" },
                values: new object[,]
                {
                    { 1, 1, "East", "Green" },
                    { 2, 1, "West", "Yellow" },
                    { 3, 1, "North", "Red" },
                    { 4, 1, "South", "Yellow" },
                    { 5, 2, "Center", "Red" },
                    { 7, 2, "West", "Green" },
                    { 6, 3, "East", "Red" },
                    { 8, 3, "West", "Red" }
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "Age", "DistrictId", "FirstName", "Gender", "IsSick", "LastName" },
                values: new object[,]
                {
                    { 1, 38, 1, "Obi-wan", "Male", false, "Kenobi" },
                    { 2, 54, 1, "Sanwise", "Male", false, "Gamgee" },
                    { 6, 84, 1, "Thomas", "Male", true, "Edison" },
                    { 7, 32, 1, "Alex", "Male", true, "Circk" },
                    { 8, 33, 1, "James", "Male", true, "Milner" },
                    { 4, 43, 2, "Consuela", "Female", false, "Tridana" },
                    { 3, 30, 3, "Hose", "Male", true, "Rodriges" },
                    { 5, 25, 3, "Ana", "Female", true, "Cormelia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Humans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
