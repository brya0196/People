using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Web.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IdProvince", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, 1, "Ciudad 1", null },
                    { 2, 2, "Ciudad 2", null },
                    { 3, 3, "Ciudad 3", null }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Provincia 1" },
                    { 2, "Provincia 2" },
                    { 3, "Provincia 3" }
                });

            migrationBuilder.InsertData(
                table: "kindServices",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Luz" },
                    { 2, "Agua" },
                    { 3, "Entretenimiento" },
                    { 4, "Salud" },
                    { 5, "Estudios" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "kindServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "kindServices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "kindServices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "kindServices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "kindServices",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
