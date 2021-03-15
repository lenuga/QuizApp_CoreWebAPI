using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp_CoreWebAPI.Migrations.Online
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "textQuestion",
                columns: table => new
                {
                    textId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionNo = table.Column<string>(maxLength: 100, nullable: false),
                    question = table.Column<string>(maxLength: 255, nullable: true),
                    quizType = table.Column<string>(maxLength: 100, nullable: true),
                    img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__textQues__CD8CEB806C22E6EB", x => x.textId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "textQuestion");
        }
    }
}
