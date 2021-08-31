namespace TheRecrutmentTool.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRecruiters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Recruiters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InterviewSlots = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_RecruiterId",
                table: "Candidates",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Recruiters_RecruiterId",
                table: "Candidates",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Recruiters_RecruiterId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "Recruiters");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_RecruiterId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Candidates");
        }
    }
}
