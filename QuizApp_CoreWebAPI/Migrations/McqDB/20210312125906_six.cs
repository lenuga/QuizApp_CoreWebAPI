using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp_CoreWebAPI.Migrations.McqDB
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mcqQuestion",
                columns: table => new
                {
                    mcqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionNo = table.Column<string>(maxLength: 100, nullable: true),
                    question = table.Column<string>(maxLength: 255, nullable: true),
                    quizType = table.Column<string>(maxLength: 100, nullable: true),
                    img = table.Column<string>(nullable: true),
                    extraAnswer = table.Column<string>(maxLength: 255, nullable: true),
                    ans = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__mcqQuest__FD2C2EC251467301", x => x.mcqId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mcqQuestion");
        }
    }
}
