
#region Import Packages
using Cart.SharedDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Cart.Domain.Interfaces
{
    public interface ICartRepository
    {
        #region Interfaces
        Task<IEnumerable<CartDTOs>> GetCartItems();
        Task<bool> RemoveItemFromCart(int id);
        Task<bool> RemoveProductFromCart(int productId);

        #endregion
    }
}
