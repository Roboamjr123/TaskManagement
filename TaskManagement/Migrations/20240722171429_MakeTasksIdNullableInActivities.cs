using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Migrations
{
    /// <inheritdoc />
    public partial class MakeTasksIdNullableInActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_Tasks_Id",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_Tasks_Id",
                table: "Activities",
                column: "Tasks_Id",
                principalTable: "Tasks",
                principalColumn: "Tasks_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Tasks_Tasks_Id",
                table: "Activities");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Tasks_Tasks_Id",
                table: "Activities",
                column: "Tasks_Id",
                principalTable: "Tasks",
                principalColumn: "Tasks_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
