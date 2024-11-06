using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Backend.Models
{
    public class Quote
    {
        [Key]
        public int QuoteID { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime QuoteDate { get; set; }

        // Add this property  
        public Customer Customer { get; set; }
        public ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
