using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flush_API.Migrations
{
    /// <inheritdoc />
    public partial class AddResultsColumnToIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Results",
                table: "Ingredient",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "Ingredient");
        }
    }
}
