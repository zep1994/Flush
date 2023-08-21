using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Flush_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateFoodItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Carbs = table.Column<double>(type: "double precision", nullable: false),
                    Proteins = table.Column<double>(type: "double precision", nullable: false),
                    Fats = table.Column<double>(type: "double precision", nullable: false),
                    HighFiberFood = table.Column<bool>(type: "boolean", nullable: false),
                    FODMAP = table.Column<bool>(type: "boolean", nullable: false),
                    DairyProduct = table.Column<bool>(type: "boolean", nullable: false),
                    Gluten = table.Column<bool>(type: "boolean", nullable: false),
                    Spicy = table.Column<bool>(type: "boolean", nullable: false),
                    FattyOrGreasyFood = table.Column<bool>(type: "boolean", nullable: false),
                    ArtificialSweetener = table.Column<bool>(type: "boolean", nullable: false),
                    HighSugarFood = table.Column<bool>(type: "boolean", nullable: false),
                    Alcohol = table.Column<bool>(type: "boolean", nullable: false),
                    ProcessedFriedFood = table.Column<bool>(type: "boolean", nullable: false),
                    CarbonatedBeverage = table.Column<bool>(type: "boolean", nullable: false),
                    ArtificialAdditive = table.Column<bool>(type: "boolean", nullable: false),
                    CoffeeTea = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItem");
        }
    }
}