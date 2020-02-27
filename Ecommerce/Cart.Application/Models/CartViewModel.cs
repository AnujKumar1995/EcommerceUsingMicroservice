namespace Cart.Application.Models
{
    public class CartViewModel
    {
        #region Properties

        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }

        #endregion
    }
}
