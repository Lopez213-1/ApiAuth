using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApi.Migrations
{
    /// <inheritdoc />
    public partial class RelacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UserId",
                table: "Tareas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tareas_Users_UserId",
                table: "Tareas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tareas_Users_UserId",
                table: "Tareas");

            migrationBuilder.DropIndex(
                name: "IX_Tareas_UserId",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tareas");
        }
    }
}
