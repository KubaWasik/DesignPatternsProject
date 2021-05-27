using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    TimeToPrepare = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredient_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mozzarella" },
                    { 11, "Arugula " },
                    { 10, "Zucchini" },
                    { 8, "Feta" },
                    { 7, "Blue cheese" },
                    { 9, "Camembert" },
                    { 5, "Salami" },
                    { 4, "Corn" },
                    { 3, "Mushroom" },
                    { 2, "Ham" },
                    { 6, "Olives" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Cost", "Description", "Name", "TimeToPrepare" },
                values: new object[,]
                {
                    { 6, 7.50m, "Pizza Quattro formaggi description", "Quattro formaggi", new TimeSpan(0, 0, 20, 0, 0) },
                    { 1, 4.50m, "Pizza Margarita description", "Margarita", new TimeSpan(0, 0, 15, 0, 0) },
                    { 2, 5.00m, "Pizza Funghi description", "Funghi", new TimeSpan(0, 0, 17, 0, 0) },
                    { 3, 5.50m, "Pizza Capriciosa description", "Capriciosa", new TimeSpan(0, 0, 18, 0, 0) },
                    { 4, 5.50m, "Pizza Salame description", "Salame", new TimeSpan(0, 0, 18, 0, 0) },
                    { 5, 6.00m, "Pizza Vegetariana description", "Vegetariana", new TimeSpan(0, 0, 16, 0, 0) },
                    { 7, 8.00m, "Pizza Deluxe description", "Deluxe", new TimeSpan(0, 0, 20, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngredient",
                columns: new[] { "Id", "IngredientId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 15, 7, 6 },
                    { 14, 1, 6 },
                    { 13, 11, 5 },
                    { 12, 10, 5 },
                    { 11, 9, 5 },
                    { 10, 1, 5 },
                    { 9, 5, 4 },
                    { 8, 1, 4 },
                    { 7, 6, 3 },
                    { 6, 3, 3 },
                    { 5, 2, 3 },
                    { 4, 1, 3 },
                    { 3, 3, 2 },
                    { 2, 1, 2 },
                    { 22, 5, 1 },
                    { 21, 4, 1 },
                    { 20, 3, 1 },
                    { 19, 2, 1 },
                    { 18, 1, 1 },
                    { 16, 8, 6 },
                    { 17, 9, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaId",
                table: "Orders",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_IngredientId",
                table: "PizzaIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredient_PizzaId",
                table: "PizzaIngredient",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PizzaIngredient");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
