using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserNameApi.Migrations
{
    /// <inheritdoc />
    public partial class FixNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Workouts",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Workouts",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Workouts",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Workouts",
                newName: "DateEnd");
        }
    }
}
