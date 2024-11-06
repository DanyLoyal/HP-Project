using System.ComponentModel.DataAnnotations;

namespace HP_Backend.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Add this property
        public ICollection<Quote> Quotes { get; set; }
    }
}