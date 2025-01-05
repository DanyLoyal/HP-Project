using HP_Backend.Data;
using HP_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HP_Backend.Controllers
{
    public class CustomerController : Controller
    {
        private readonly XdcCpqContext _context;

        public CustomerController(XdcCpqContext context)
        {
            _context = context;
        }

        // GET: /Customer/SelectOrAdd
        public async Task<IActionResult> SelectOrAdd()
        {
            var customers = await _context.Customers.ToListAsync();
            return View(customers);
        }

        // POST: /Customer/Add
        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("SelectOrAdd");
            }
            return View("SelectOrAdd", await _context.Customers.ToListAsync());
        }
    }
}
