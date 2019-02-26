using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Web.Migrations
{
    public partial class AddedPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Residences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residences_UserId",
                table: "Residences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_AspNetUsers_UserId",
                table: "Residences",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_AspNetUsers_UserId",
                table: "Residences");

            migrationBuilder.DropIndex(
                name: "IX_Residences_UserId",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Residences");
        }
    }
}
