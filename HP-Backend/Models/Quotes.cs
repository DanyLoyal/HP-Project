using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Backend.Models
{
    public class Quotes
    {
        [Key]
        public int QuoteID { get; set; }
        public int CustomerID { get; set; }
        public DateTime QuoteDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        // Additional properties as needed
    }
}
