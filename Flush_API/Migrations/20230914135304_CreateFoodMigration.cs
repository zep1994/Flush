using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Flush_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateFoodMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Carbs = table.Column<double>(type: "double precision", nullable: true),
                    Proteins = table.Column<double>(type: "double precision", nullable: true),
                    Fats = table.Column<double>(type: "double precision", nullable: true),
                    HighFiberFood = table.Column<bool>(type: "boolean", nullable: true),
                    FODMAP = table.Column<bool>(type: "boolean", nullable: true),
                    DairyProduct = table.Column<bool>(type: "boolean", nullable: true),
                    Gluten = table.Column<bool>(type: "boolean", nullable: true),
                    Spicy = table.Column<bool>(type: "boolean", nullable: true),
                    FattyOrGreasyFood = table.Column<bool>(type: "boolean", nullable: true),
                    ArtificialSweetener = table.Column<bool>(type: "boolean", nullable: true),
                    HighSugarFood = table.Column<bool>(type: "boolean", nullable: true),
                    Alcohol = table.Column<bool>(type: "boolean", nullable: true),
                    ProcessedFriedFood = table.Column<bool>(type: "boolean", nullable: true),
                    CarbonatedBeverage = table.Column<bool>(type: "boolean", nullable: true),
                    ArtificialAdditive = table.Column<bool>(type: "boolean", nullable: true),
                    CoffeeTea = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserLogin");
        }
    }
}
