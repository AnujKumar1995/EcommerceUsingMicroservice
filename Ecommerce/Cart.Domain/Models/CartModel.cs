using System.ComponentModel.DataAnnotations;

namespace Cart.Domain.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
