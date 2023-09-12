using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Flush_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateMealAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "Ingredient");

            migrationBuilder.AddColumn<bool>(
                name: "Alcohol",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArtificialAdditive",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ArtificialSweetener",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CarbonatedBeverage",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "CoffeeTea",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DairyProduct",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "FODMAP",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Fats",
                table: "Ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "FattyOrGreasyFood",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gluten",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HighFiberFood",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HighSugarFood",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ProcessedFriedFood",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Proteins",
                table: "Ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Spicy",
                table: "Ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MealName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealFoodItems",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    FoodItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFoodItems", x => new { x.MealId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_MealFoodItems_FoodItem_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFoodItems_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealFoodItems_FoodItemId",
                table: "MealFoodItems",
                column: "FoodItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFoodItems");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ArtificialAdditive",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ArtificialSweetener",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CarbonatedBeverage",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "CoffeeTea",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "DairyProduct",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FODMAP",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Fats",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "FattyOrGreasyFood",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Gluten",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "HighFiberFood",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "HighSugarFood",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ProcessedFriedFood",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Proteins",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Spicy",
                table: "Ingredient");

            migrationBuilder.AddColumn<string[]>(
                name: "Results",
                table: "Ingredient",
                type: "text[]",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FoodItem",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
