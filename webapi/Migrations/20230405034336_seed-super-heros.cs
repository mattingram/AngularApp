using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class seedsuperheros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SuperHeros",
                columns: new[] { "Id", "FirstName", "LastName", "Name", "Place" },
                values: new object[] { -1, "Peter", "Parker", "Spider Man", "NYC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperHeros",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
