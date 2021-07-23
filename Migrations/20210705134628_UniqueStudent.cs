using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnerAPI.Migrations
{
    public partial class UniqueStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StudentNumber",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_StudentNumber",
                table: "Students",
                column: "StudentNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Students_StudentNumber",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "StudentNumber",
                table: "Students",
                type: "int",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
