using Microsoft.EntityFrameworkCore.Migrations;

namespace SDATA.Migrations
{
    public partial class InitialCreateLite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Value 101" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Value 102" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Value 103" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[] { 4, "Value 104" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "ID", "Name" },
                values: new object[] { 5, "Value 105" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
