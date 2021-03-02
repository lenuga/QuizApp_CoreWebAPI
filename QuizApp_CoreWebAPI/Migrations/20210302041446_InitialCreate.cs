using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp_CoreWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emailId = table.Column<string>(maxLength: 255, nullable: true),
                    address = table.Column<string>(maxLength: 255, nullable: true),
                    phoneNo = table.Column<string>(maxLength: 50, nullable: true),
                    userType = table.Column<string>(maxLength: 50, nullable: true),
                    firstName = table.Column<string>(maxLength: 255, nullable: true),
                    password = table.Column<string>(maxLength: 255, nullable: true),
                    lastName = table.Column<string>(maxLength: 255, nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInfo__CB9A1CFF43C258F2", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
