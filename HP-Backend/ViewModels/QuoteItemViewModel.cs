namespace HP_Backend.ViewModels
{
    public class QuoteItemViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Discount { get; set; } // som procent
        public decimal FinalPrice { get; set; }
    }
}