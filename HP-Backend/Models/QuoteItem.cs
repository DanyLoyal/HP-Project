using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Backend.Models
{
    public class QuoteItem
    {
        [Key]
        public int QuoteItemID { get; set; }
        public int QuoteID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        // Additional properties as needed

        public Quote Quote { get; set; }
        public Product Product { get; set; }
    }
}
