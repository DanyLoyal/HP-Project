namespace HP_Backend.Models
{
    public class QuoteItem
    {
        public int QuoteItemID { get; set; }
        public int QuoteID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Additional properties as needed
    }
}
