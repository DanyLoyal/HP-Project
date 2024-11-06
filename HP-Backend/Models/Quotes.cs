namespace HP_Backend.Models
{
    public class Quotes
    {
        public int QuoteID { get; set; }
        public int CustomerID { get; set; }
        public DateTime QuoteDate { get; set; }
        public decimal TotalPrice { get; set; }
        // Additional properties as needed
    }
}
