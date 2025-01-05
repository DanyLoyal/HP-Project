using HP_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HP_Backend.Data
{
    public class XdcCpqContext : DbContext
    {
        public XdcCpqContext(DbContextOptions<XdcCpqContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Customer)
                .WithMany(c => c.Quotes)
                .HasForeignKey(q => q.CustomerID);

            modelBuilder.Entity<QuoteItem>()
                .HasOne(qi => qi.Quote)
                .WithMany(q => q.QuoteItems)
                .HasForeignKey(qi => qi.QuoteID);

            modelBuilder.Entity<QuoteItem>()
                .HasOne(qi => qi.Product)
                .WithMany(p => p.QuoteItems)
                .HasForeignKey(qi => qi.ProductID);

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Product A", Description = "License for Product A", MonthlyPrice = 15.99M, AnnualPrice = 159.99M },
                new Product { ProductID = 2, Name = "Product B", Description = "Subscription for Product B", MonthlyPrice = 25.99M, AnnualPrice = 259.99M }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
                new Customer { CustomerId = 2, Name = "Bob Smith", Email = "bob.smith@example.com" }
            );

            // Seed Quotes - Use CustomerID only, no Customer object or QuoteItems
            modelBuilder.Entity<Quote>().HasData(
                new Quote { QuoteID = 1, CustomerID = 1, TotalPrice = 159.99M, QuoteDate = DateTime.UtcNow },
                new Quote { QuoteID = 2, CustomerID = 2, TotalPrice = 259.99M, QuoteDate = DateTime.UtcNow }
            );

            // Seed QuoteItems - Use ProductID and QuoteID only, no Product object
            modelBuilder.Entity<QuoteItem>().HasData(
                new QuoteItem { QuoteItemID = 1, QuoteID = 1, ProductID = 1, Quantity = 27, Price = 159.99M },
                new QuoteItem { QuoteItemID = 2, QuoteID = 1, ProductID = 2, Quantity = 100, Price = 259.99M }
            );

            base.OnModelCreating(modelBuilder);
        }

        // Helper method to get Quotes with all related data
        public async Task<List<Quote>> GetQuotesWithDetailsAsync()
        {
            return await Quotes
                .Include(q => q.Customer)
                .Include(q => q.QuoteItems)
                    .ThenInclude(qi => qi.Product)
                .ToListAsync();
        }

        // Helper method to get QuoteItems with all related data
        public async Task<List<QuoteItem>> GetQuoteItemsWithDetailsAsync()
        {
            return await QuoteItems
                .Include(qi => qi.Quote)
                .Include(qi => qi.Product)
                .ToListAsync();
        }
    }
}
