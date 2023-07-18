using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flush_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnsFromIngredientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Flavonoids",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "MetaInformation",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Nutrition",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "Ingredient");

            migrationBuilder.AlterColumn<string[]>(
                name: "Results",
                table: "Ingredient",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Results",
                table: "Ingredient",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0],
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Flavonoids",
                table: "Ingredient",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ingredient",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "MetaInformation",
                table: "Ingredient",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredient",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Nutrition",
                table: "Ingredient",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Properties",
                table: "Ingredient",
                type: "text[]",
                nullable: true);
        }
    }
}
