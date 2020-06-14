using Microsoft.EntityFrameworkCore.Migrations;

namespace SDATA.Migrations
{
    public partial class SeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Value 101" },
                    { 2, "Value 102" },
                    { 3, "Value 103" },
                    { 4, "Value 104" },
                    { 5, "Value 105" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
