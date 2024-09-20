using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addevents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "Id");
        }
    }
}
