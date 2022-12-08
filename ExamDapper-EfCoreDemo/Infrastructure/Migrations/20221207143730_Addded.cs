using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TodoListImages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoListImages",
                newName: "ImageName");

            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "TodoListImages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoListImages_TodoListId",
                table: "TodoListImages",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListImages_TodoLists_TodoListId",
                table: "TodoListImages",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoListImages_TodoLists_TodoListId",
                table: "TodoListImages");

            migrationBuilder.DropIndex(
                name: "IX_TodoListImages_TodoListId",
                table: "TodoListImages");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "TodoListImages");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "TodoListImages",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TodoListImages",
                type: "text",
                nullable: true);
        }
    }
}
