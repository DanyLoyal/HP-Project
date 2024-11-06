using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HP_Backend.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MonthlyPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AnnualPrice { get; set; }
        // Additional properties as needed
    }
}