﻿using System.ComponentModel.DataAnnotations;

namespace HP_Backend.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal AnnualPrice { get; set; }
        public ICollection<QuoteItem> QuoteItems { get; set; } // Add this property
    }
}