using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HP_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "alice.johnson@example.com", "Alice Johnson" },
                    { 2, "bob.smith@example.com", "Bob Smith" },
                    { 3, "sdasda@sadasd.com", "Charlie Brown" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "AnnualPrice", "Description", "MonthlyPrice", "Name" },
                values: new object[,]
                {
                    { 1, 159.99m, "License for Product A", 15.99m, "Product A" },
                    { 2, 259.99m, "Subscription for Product B", 25.99m, "Product B" },
                    { 3, 109.99m, "License for Product C", 10.99m, "Product C" },
                    { 4, 209.99m, "Subscription for Product D", 20.99m, "Product D" },
                    { 5, 59.99m, "License for Product E", 5.99m, "Product E" },
                    { 6, 309.99m, "Subscription for Product F", 30.99m, "Product F" },
                    { 7, 129.99m, "License for Product G", 12.99m, "Product G" },
                    { 8, 359.99m, "Subscription for Product H", 35.99m, "Product H" },
                    { 9, 89.99m, "License for Product I", 8.99m, "Product I" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);
        }
    }
}
