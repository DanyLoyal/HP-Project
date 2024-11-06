using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HP_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly XdcCpqContext _context;

        public QuoteController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quotes>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        // Other CRUD actions (POST, PUT, DELETE)
    }


}
