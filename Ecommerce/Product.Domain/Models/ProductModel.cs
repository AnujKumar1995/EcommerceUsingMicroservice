
#region Import Packages
using System.ComponentModel.DataAnnotations;
#endregion

namespace Product.Domain.Models
{
    public class ProductModel
    {
        #region Properties
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        #endregion
    }
}
