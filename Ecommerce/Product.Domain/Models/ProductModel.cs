using System.ComponentModel.DataAnnotations;

namespace Product.Domain.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
