using HP_Backend.Models;
using Microsoft.EntityFrameworkCore;
namespace HP_Backend.Controllers
{
    public class XdcCpqContext : DbContext
    {
        public XdcCpqContext(DbContextOptions<XdcCpqContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }
    }

}
