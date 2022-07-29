using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompletionCafe.Migrations
{
    public partial class DaysLeftClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategorys");

            migrationBuilder.DropColumn(
                name: "DaysLeft",
                table: "Accomplishments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DaysLeft",
                table: "Accomplishments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserCategorys",
                columns: table => new
                {
                    UserDefinedCategory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategorys", x => x.UserDefinedCategory);
                });
        }
    }
}
