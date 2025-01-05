using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HP_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuoteItenSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteID", "CustomerID", "QuoteDate", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 6, 14, 15, 4, 314, DateTimeKind.Utc).AddTicks(5538), 159.99m },
                    { 2, 2, new DateTime(2024, 11, 6, 14, 15, 4, 314, DateTimeKind.Utc).AddTicks(5540), 259.99m }
                });

            migrationBuilder.InsertData(
                table: "QuoteItems",
                columns: new[] { "QuoteItemID", "Price", "ProductID", "Quantity", "QuoteID" },
                values: new object[,]
                {
                    { 1, 159.99m, 1, 27, 1 },
                    { 2, 259.99m, 2, 100, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CustomerID",
                table: "Quotes",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_ProductID",
                table: "QuoteItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteItems_QuoteID",
                table: "QuoteItems",
                column: "QuoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Products_ProductID",
                table: "QuoteItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems",
                column: "QuoteID",
                principalTable: "Quotes",
                principalColumn: "QuoteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Customers_CustomerID",
                table: "Quotes",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Products_ProductID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteItems_Quotes_QuoteID",
                table: "QuoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Customers_CustomerID",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CustomerID",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_QuoteItems_ProductID",
                table: "QuoteItems");

            migrationBuilder.DropIndex(
                name: "IX_QuoteItems_QuoteID",
                table: "QuoteItems");

            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "QuoteItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuoteItems",
                keyColumn: "QuoteItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteID",
                keyValue: 1);
        }
    }
}
