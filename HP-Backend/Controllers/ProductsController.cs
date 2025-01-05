using HP_Backend.Data;
using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HP_Backend.Controllers
{
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly XdcCpqContext _context;

        public ProductsController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: /Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products); // Returns the 'Index' view with the list of products
        }

        // GET: /Products/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Returns the 'Details' view with the specific product
        }
    }
}
