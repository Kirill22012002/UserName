using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserNameApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedCurrentWorkoutIdAndCurrentSessionIdForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Workouts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CurrentSessionId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CurrentWorkoutId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "CurrentSessionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentWorkoutId",
                table: "AspNetUsers");
        }
    }
}
