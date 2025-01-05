using Xunit;
using HP_Backend.Controllers;
using HP_Backend.Models;
using HP_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HP_Backend.Tests.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public async Task Add_ValidCustomer_RedirectsToSelectOrAdd()
        {
            // Arrange
            // 1. Opret in-memory DB-options.
            var options = new DbContextOptionsBuilder<XdcCpqContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_CustomerController_AddValid")
                .Options;

            // 2. Instantiér en ny context og controller
            using var context = new XdcCpqContext(options);
            var controller = new CustomerController(context);

            // 3. Opret en gyldig kunde
            var newCustomer = new Customer
            {
                Name = "Valid Customer",
                Email = "valid@example.com"
            };

            // Act
            // Kald Add()-metoden i controlleren
            var result = await controller.Add(newCustomer);

            // Assert
            // 1. Tjek at result er et RedirectToActionResult
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("SelectOrAdd", redirectResult.ActionName);

            // 2. Tjek at kunden faktisk er gemt
            Assert.Single(context.Customers);
        }

        [Fact]
        public async Task Add_InvalidCustomer_ReturnsView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<XdcCpqContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_CustomerController_AddInvalid")
                .Options;

            using var context = new XdcCpqContext(options);
            var controller = new CustomerController(context);

            // Gør modelstaten ugyldig (f.eks. mangler navn)
            controller.ModelState.AddModelError("Name", "Name is required");

            var invalidCustomer = new Customer
            {
                Name = "",              // Ugyldigt pga. tomt navn
                Email = "test@fail.com" // (E-mail er ok, men navnet mangler)
            };

            // Act
            var result = await controller.Add(invalidCustomer);

            // Assert
            // Forventer at det returneres et ViewResult, ikke Redirect
            var viewResult = Assert.IsType<ViewResult>(result);

            // Fordi vi i controlleren returnerer f.eks.:
            //   return View("SelectOrAdd", ...)
            // kan vi tjekke at ViewName er "SelectOrAdd"
            Assert.Equal("SelectOrAdd", viewResult.ViewName);

            // Tjek at ingen kunder er gemt i databasen
            Assert.Empty(context.Customers);
        }
    }
}
