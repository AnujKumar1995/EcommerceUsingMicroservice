#region Import Packages
using System.ComponentModel.DataAnnotations;
#endregion

namespace Cart.Domain.Models
{
    public class CartModel
    {
        #region Properties

        [Key]
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }

        #endregion
    }
}
