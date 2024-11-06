using HP_Backend.Models;
using Microsoft.EntityFrameworkCore;

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
                new Product
                {
                    ProductID = 1,
                    Name = "Product A",
                    Description = "License for Product A",
                    MonthlyPrice = 15.99M,
                    AnnualPrice = 159.99M
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Product B",
                    Description = "Subscription for Product B",
                    MonthlyPrice = 25.99M,
                    AnnualPrice = 259.99M
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Product C",
                    Description = "License for Product C",
                    MonthlyPrice = 10.99M,
                    AnnualPrice = 109.99M
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Product D",
                    Description = "Subscription for Product D",
                    MonthlyPrice = 20.99M,
                    AnnualPrice = 209.99M
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Product E",
                    Description = "License for Product E",
                    MonthlyPrice = 5.99M,
                    AnnualPrice = 59.99M
                },
                new Product
                {
                    ProductID = 6,
                    Name = "Product F",
                    Description = "Subscription for Product F",
                    MonthlyPrice = 30.99M,
                    AnnualPrice = 309.99M
                },
                new Product
                {
                    ProductID = 7,
                    Name = "Product G",
                    Description = "License for Product G",
                    MonthlyPrice = 12.99M,
                    AnnualPrice = 129.99M
                },
                new Product
                {
                    ProductID = 8,
                    Name = "Product H",
                    Description = "Subscription for Product H",
                    MonthlyPrice = 35.99M,
                    AnnualPrice = 359.99M
                },
                new Product
                {
                    ProductID = 9,
                    Name = "Product I",
                    Description = "License for Product I",
                    MonthlyPrice = 8.99M,
                    AnnualPrice = 89.99M
                }
                // Add more products as needed
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com"
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Bob Smith",
                    Email = "bob.smith@example.com"
                },
                new Customer
                {
                    CustomerId = 3,
                    Name = "Charlie Brown",
                    Email = "sdasda@sadasd.com"
                }
                // Add more customers as needed
            );

            // Seed other entities if necessary
            // Seed Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote
                {
                    QuoteID = 1,
                    CustomerID = 1, // Must match an existing CustomerID
                    TotalPrice = 159.99M,
                    QuoteDate = DateTime.UtcNow
                },
                new Quote
                {
                    QuoteID = 2,
                    CustomerID = 2, // Must match an existing CustomerID
                    TotalPrice = 259.99M,
                    QuoteDate = DateTime.UtcNow
                }
            );

            // Seed QuoteItems
            modelBuilder.Entity<QuoteItem>().HasData(
                new QuoteItem
                {
                    QuoteItemID = 1,
                    QuoteID = 1,    // Must match an existing QuoteID
                    ProductID = 1,  // Must match an existing ProductID
                    Quantity = 27,
                    Price = 159.99M
                },
                new QuoteItem
                {
                    QuoteItemID = 2,
                    QuoteID = 1,    // Must match an existing QuoteID
                    ProductID = 2,  // Must match an existing ProductID
                    Quantity = 100,
                    Price = 259.99M
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
