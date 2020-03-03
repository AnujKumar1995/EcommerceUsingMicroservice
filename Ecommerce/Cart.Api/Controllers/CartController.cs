
#region Import Packages

using AutoMapper;
using Cart.Application.Interfaces;
using Cart.Application.Models;
using Cart.SharedDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion


namespace Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region Instance
        private readonly ICartService _service;
        private readonly IMapper _mapper;
        private bool flag;
        #endregion

        #region Constructor
        public CartController(ICartService service)
        {
            _service = service;

            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartViewModel, CartDTOs>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region Get All Cart Items
        // GET: api/Cart
        [HttpGet("GetItems")]
        public async Task<IEnumerable<CartViewModel>> CartItems(string email)
        {
            var cartItems = await Task.FromResult(_mapper.Map<IEnumerable<CartDTOs>>(await _service.GetCartItems(email)));
            return _mapper.Map<IEnumerable<CartViewModel>>(cartItems);
        }
        #endregion

        #region Remove Item from Cart
        [HttpDelete("RemoveItemFromCart")]
        public async Task<bool> RemoveItemFromCart(int cartId)
        {
            try
            {
                flag = await _service.RemoveItemFromCart(cartId);
                return await Task.FromResult(flag);
            }
            catch
            {
                return await Task.FromResult(flag);
            }
        }
        #endregion

        #region Remove Product from Cart with productId
        [HttpDelete("RemoveProductFromCart")]
        public async Task<bool> RemoveProductFromCart(int productID)
        {
            try
            {
                flag = await _service.RemoveProductFromCart(productID);
                return await Task.FromResult(flag);
            }
            catch
            {
                return await Task.FromResult(flag);
            }
        }
        #endregion
    }
}
