using HP_Backend.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace HP_Backend.Controllers
{
        [Route("api/customers")]
        [ApiController]
        public class CustomerController : ControllerBase
        {
            private readonly XdcCpqContext _context;

            public CustomerController(XdcCpqContext context)
            {
                _context = context;
            }

            // GET: api/customers
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
            {
                return await _context.Customers.ToListAsync();
            }

            // Other CRUD actions (POST, PUT, DELETE)
        }
}
