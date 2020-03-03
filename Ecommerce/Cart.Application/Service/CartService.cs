
#region Import Packages

using Cart.Application.Interfaces;
using Cart.Domain.Interfaces;
using Cart.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Cart.Application.Service
{
    public class CartService : ICartService
    {
        #region Instance
        private readonly ICartRepository _cart;
        private  bool flag;
        #endregion

        #region Constructor
        public CartService(ICartRepository cartRepository)
        {
            _cart = cartRepository;
        }
        #endregion

        #region Get All Items from cart
        public async Task<IEnumerable<CartDTOs>> GetCartItems(string email)
        {
            var items = await Task.FromResult(await _cart.GetCartItems(email));
            return items;
            
        }
        #endregion

        #region Request To Remove Item from cart with cartId
        public async Task<bool> RemoveItemFromCart(int cartId)
        {
            try
            {
                if (cartId > 0)
                {
                    flag = await _cart.RemoveItemFromCart(cartId);
                    return await Task.FromResult(flag);
                }
                else
                {
                    return await Task.FromResult(flag);
                }
            }catch
            {
                return await Task.FromResult(flag);
            }
        }
        #endregion

        #region Request To Remove Product from cart with productID
        public async Task<bool> RemoveProductFromCart(int productId)
        {
            try
            {
                if (productId > 0)
                {
                    flag = await _cart.RemoveProductFromCart(productId);
                    return await Task.FromResult(flag);
                }
                else
                {
                    return await Task.FromResult(flag);
                }
            }
            catch
            {
                return await Task.FromResult(flag);
            }
        }
        #endregion
    }
}
