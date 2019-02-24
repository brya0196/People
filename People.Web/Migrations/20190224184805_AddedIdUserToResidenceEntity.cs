using Microsoft.EntityFrameworkCore.Migrations;

namespace People.Web.Migrations
{
    public partial class AddedIdUserToResidenceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Residences",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Residences");
        }
    }
}
