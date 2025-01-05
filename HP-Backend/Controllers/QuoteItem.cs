using HP_Backend.Data;
using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HP_Backend.Controllers
{
    [Route("[controller]")]
    public class QuoteItemController : Controller
    {
        private readonly XdcCpqContext _context;

        public QuoteItemController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: /QuoteItem
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var quoteItems = await _context.QuoteItems.ToListAsync();
            return View(quoteItems); // Returns the 'Index' view with the list of quote items
        }

        // GET: /QuoteItem/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var quoteItem = await _context.QuoteItems.FirstOrDefaultAsync(qi => qi.QuoteItemID == id);
            if (quoteItem == null)
            {
                return NotFound();
            }
            return View(quoteItem); // Returns the 'Details' view with the specific quote item
        }
    }
}
