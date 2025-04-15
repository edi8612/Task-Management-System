using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudySync.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Tasks_TaskId",
                table: "Subtasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Subtasks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Tasks_TaskId",
                table: "Subtasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subtasks_Tasks_TaskId",
                table: "Subtasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Subtasks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subtasks_Tasks_TaskId",
                table: "Subtasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
