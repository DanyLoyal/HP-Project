using Xunit;
using HP_Backend.Controllers;
using HP_Backend.Models;
using HP_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace HP_Backend.Tests.Controllers
{
    public class QuoteControllerTests
    {
        [Fact]
        public async Task SelectProducts_ValidCustomerId_ReturnsViewWithCustomerAndProducts()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<XdcCpqContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_QuoteController_SelectProducts_Valid")
                .Options;

            using var context = new XdcCpqContext(options);

            // Opretter en kunde
            var customer = new Customer
            {
                Name = "Test Customer",
                Email = "test@example.com"
            };
            context.Customers.Add(customer);

            // Opretter produkt (Nu med navnet "Laptop Pro" + en Description)
            var product = new Product
            {
                ProductID = 1,
                Name = "Laptop Pro",
                Description = "High-end laptop", // <-- Tilføj beskrivelse
                MonthlyPrice = 100m,
                AnnualPrice = 1000m
            };
            context.Products.Add(product);

            await context.SaveChangesAsync();

            var controller = new QuoteController(context);

            // ACT
            var result = await controller.SelectProducts(customer.CustomerId);

            // ASSERT
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.True(viewResult.ViewData.ContainsKey("Customer"));
            Assert.True(viewResult.ViewData.ContainsKey("Products"));

            var returnedCustomer = viewResult.ViewData["Customer"] as Customer;
            Assert.NotNull(returnedCustomer);
            Assert.Equal(customer.CustomerId, returnedCustomer.CustomerId);

            var returnedProducts = viewResult.ViewData["Products"] as List<Product>;
            Assert.NotNull(returnedProducts);
            Assert.Single(returnedProducts);
            // Nu passer navnene sammen
            Assert.Equal("Laptop Pro", returnedProducts[0].Name);
        }

        [Fact]
        public async Task SelectProducts_InvalidCustomerId_ReturnsNotFound()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<XdcCpqContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_QuoteController_SelectProducts_Invalid")
                .Options;

            using var context = new XdcCpqContext(options);

            // Ingen kunder i databasen
            var controller = new QuoteController(context);

            // ACT
            var result = await controller.SelectProducts(9999);

            // ASSERT
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains("9999", notFoundResult.Value?.ToString());
        }

        [Fact]
        public void QuoteSummary_ValidData_ReturnsViewWithCorrectTotalPrice()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<XdcCpqContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_QuoteController_QuoteSummary_Valid")
                .Options;

            using var context = new XdcCpqContext(options);

            // Tilføj en kunde
            var customer = new Customer
            {
                Name = "Test Customer",
                Email = "test@example.com"
            };
            context.Customers.Add(customer);

            // Tilføj et produkt - husk Description
            var product = new Product
            {
                ProductID = 1,
                Name = "Cloud Service",
                Description = "Cloud-based solution", // <-- Tilføj beskrivelse
                MonthlyPrice = 100m,
                AnnualPrice = 1000m
            };
            context.Products.Add(product);

            context.SaveChanges();

            var controller = new QuoteController(context);

            // 2 stk. a 100 kr, 10% rabat => 180 kr
            var productIds = new List<int> { 1 };
            var quantities = new List<int> { 2 };
            var discounts = new List<int> { 10 };

            // ACT
            var result = controller.QuoteSummary(customer.CustomerId, productIds, quantities, discounts);

            // ASSERT
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("QuoteSummary", viewResult.ViewName);

            Assert.True(viewResult.ViewData.ContainsKey("TotalPrice"));
            var totalPrice = (decimal)viewResult.ViewData["TotalPrice"];
            Assert.Equal(180m, totalPrice);

            Assert.True(viewResult.ViewData.ContainsKey("QuoteItems"));
            var quoteItems = viewResult.ViewData["QuoteItems"] as List<QuoteItemViewModel>;
            Assert.NotNull(quoteItems);
            Assert.Single(quoteItems);

            var item = quoteItems[0];
            Assert.Equal("Cloud Service", item.ProductName);
            Assert.Equal(2, item.Quantity);
            Assert.Equal(180m, item.FinalPrice);
        }
    }
}
