using HP_Backend.Data;
using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace HP_Backend.Controllers
{
    public class QuoteController : Controller
    {
        private readonly XdcCpqContext _context;

        public QuoteController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: /Quote/SelectProducts
        public async Task<IActionResult> SelectProducts(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }

            var products = await _context.Products.ToListAsync();
            if (!products.Any())
            {
                return NotFound("No products available.");
            }

            ViewData["Customer"] = customer;
            ViewData["Products"] = products;

            return View(); // Viser SelectProducts.cshtml
        }

        [HttpPost]
        public IActionResult ConfigurePrices(int customerId, List<int> productIds, List<int> quantities)
        {
            try
            {
                var (customer, quoteItems) = BuildQuote(customerId, productIds, quantities);

                // Serialiser quoteItems (ViewModels) til JSON i TempData
                TempData["CustomerId"] = customerId;
                TempData["QuoteItems"] = JsonSerializer.Serialize(quoteItems);

                return RedirectToAction("ConfigurePricesView");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ConfigurePricesView()
        {
            if (TempData["CustomerId"] == null || TempData["QuoteItems"] == null)
            {
                return BadRequest("Missing required data.");
            }

            var customerId = (int)TempData["CustomerId"];
            var quoteItemsJson = (string)TempData["QuoteItems"];
            var quoteItems = JsonSerializer.Deserialize<List<QuoteItemViewModel>>(quoteItemsJson);

            var customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }

            // Sørg for at der rent faktisk er data i quoteItems
            if (quoteItems == null || !quoteItems.Any())
            {
                return BadRequest("No quote items available.");
            }

            ViewData["Customer"] = customer;
            ViewData["QuoteItems"] = quoteItems;

            return View("ConfigurePrices");
        }


        [HttpPost]
        public IActionResult QuoteSummary(int customerId, List<int> productIds, List<int> quantities, List<int> discounts)
        {
            try
            {
                var (customer, quoteItems) = BuildQuote(customerId, productIds, quantities, discounts);
                var totalPrice = quoteItems.Sum(item => item.FinalPrice);

                ViewData["Customer"] = customer;
                ViewData["QuoteItems"] = quoteItems;
                ViewData["TotalPrice"] = totalPrice;

                return View("QuoteSummary");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private (Customer customer, List<QuoteItemViewModel>) BuildQuote(
            int customerId,
            List<int> productIds,
            List<int> quantities,
            List<int>? discounts = null)
        {
            if (productIds == null || quantities == null || productIds.Count != quantities.Count)
            {
                throw new ArgumentException("Invalid product or quantity data.");
            }

            var customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} not found.");
            }

            var products = _context.Products.Where(p => productIds.Contains(p.ProductID)).ToList();
            if (!products.Any())
            {
                throw new ArgumentException("No valid products found.");
            }

            var quoteItems = new List<QuoteItemViewModel>();
            for (int i = 0; i < productIds.Count; i++)
            {
                var product = products.FirstOrDefault(p => p.ProductID == productIds[i]);
                if (product != null)
                {
                    var quantity = quantities[i];
                    var discount = discounts != null && i < discounts.Count ? discounts[i] / 100.0m : 0m;
                    var finalPrice = product.MonthlyPrice * quantity * (1 - discount);

                    quoteItems.Add(new QuoteItemViewModel
                    {
                        ProductID = product.ProductID,
                        ProductName = product.Name,
                        Description = product.Description,
                        Quantity = quantity,
                        Discount = (int)(discount * 100),
                        FinalPrice = finalPrice
                    });
                }
            }

            return (customer, quoteItems);
        }
    }

    // ViewModel klasse til at repræsentere de data, viewet har brug for
    public class QuoteItemViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public String Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Discount { get; set; } // As a percentage
        public decimal FinalPrice { get; set; }
    }
}
