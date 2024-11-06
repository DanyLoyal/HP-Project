using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HP_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteItemController : ControllerBase
    {
        private readonly XdcCpqContext _context;

        public QuoteItemController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: api/QuoteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteItem>>> GetQuoteItems()
        {
            return await _context.QuoteItems.ToListAsync();
        }

        // Other CRUD actions (POST, PUT, DELETE)
    }
}
